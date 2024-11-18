open System.IO
open FSharp.Formatting.Markdown

module Constants =

    let sourceDir = __SOURCE_DIRECTORY__
    let markdownDir = Path.Combine(sourceDir, "markdown")
    let outputDir = Path.Combine(sourceDir, "output")
    let partialsDir = Path.Combine(sourceDir, "partials")
    let imagesDir = Path.Combine(markdownDir, "images")
    let outputImagesDir = Path.Combine(outputDir, "images")

    let cssDir = Path.Combine(sourceDir, "css")

    let fontDir = Path.Combine(sourceDir, "font")

module diskUtils =

    let readFile (path: string) =
        path
        |> File.Exists
        |> function
            | true -> File.ReadAllText(path)
            | false -> ""

    let writeFile (path: string) (content: string) = File.WriteAllText(path, content)

    let copyFilesToOutput (sourceDir: string) (searchPattern: string) =
        let files = Directory.GetFiles(sourceDir, searchPattern)

        files
        |> Array.iter (fun file ->
            let fileName = Path.GetFileName(file)
            let destinationPath = Path.Combine(Constants.outputDir, fileName)
            File.Copy(file, destinationPath, true))

    let copyImagesToOutput () =
        if not (Directory.Exists(Constants.outputImagesDir)) then
            Directory.CreateDirectory(Constants.outputImagesDir)
            |> ignore

        Directory.GetFiles(Constants.imagesDir)
        |> Array.iter (fun file ->
            let fileName = Path.GetFileName(file)
            let destFile = Path.Combine(Constants.outputImagesDir, fileName)
            File.Copy(file, destFile, true))



module urlUtils =
    let toUrlFriendly (input: string) =
        input.ToLowerInvariant()
        |> fun text -> System.Text.RegularExpressions.Regex.Replace(text, @"[^\w\s]", "") // Remove all non-alphanumeric characters
        |> fun text -> System.Text.RegularExpressions.Regex.Replace(text, @"\s+", "-") // Replace spaces with hyphens

let generateFinalHtml (header: string) (footer: string) (content: string) (title: string) =
    $"""
    <!DOCTYPE html>
    <html lang="en" color-mode="user">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link rel="stylesheet" href="styles.css">
        <title>{title}</title>
        <link rel="apple-touch-icon" sizes="180x180" href="images/apple-touch-icon.png">
        <link rel="icon" type="image/png" sizes="32x32" href="images/favicon-32x32.png">
        <link rel="icon" type="image/png" sizes="16x16" href="images/favicon-16x16.png">
        <link rel="manifest" href="images/site.webmanifest">
        <link rel="mask-icon" href="images/safari-pinned-tab.svg" color="#5bbad5">
        <link rel="shortcut icon" href="images/favicon.ico">
        <meta name="msapplication-TileColor" content="#da532c">
        <meta name="msapplication-config" content="images/browserconfig.xml">
        <meta name="theme-color" content="#ffffff">
    </head>
    <body>
        <header>{header}
        </header>
        <main>
            {content}
        </main>
        <hr />
        <footer>
            {footer}
        </footer>
    </body>
    </html>
    """

let isArticle (file: string) =
    System.Char.IsDigit(Path.GetFileName(file).[0])

let createPage (header: string) (footer: string) (markdownFilePath: string) =
    let title =
        File.ReadAllLines(markdownFilePath)
        |> Array.tryFind (fun line -> line.StartsWith("# "))
        |> Option.defaultValue "# No Title"
        |> fun title -> title.TrimStart('#').Trim()

    let fileName = urlUtils.toUrlFriendly (title)
    let outputMarkdownFilePath = Path.Combine(Constants.outputDir, fileName + ".html")
    let markdownContent = File.ReadAllText(markdownFilePath)

    let htmlContent =
        match isArticle (markdownFilePath) with
        | false -> Markdown.ToHtml(markdownContent)
        | true ->
            let date = Path.GetFileNameWithoutExtension(markdownFilePath)

            let publicationDate =
                $"""<p class="publication-date">Published on <time datetime="{date}">{date}</time></p>"""

            let giscus = diskUtils.readFile (Path.Combine(Constants.partialsDir, "giscus.inc"))

            Markdown.ToHtml(
                markdownContent
                + "\n\n"
                + publicationDate
                + "\n\n"
                + giscus
            )

    let finalHtmlContent =
        generateFinalHtml header footer htmlContent ("Max Gripe 1982 - " + title)

    diskUtils.writeFile outputMarkdownFilePath finalHtmlContent

let createIndexPage (header: string) (footer: string) (listOfAllArticles: (string * string * string) list) =
    let indexMarkdownPath = Path.Combine(Constants.sourceDir, "markdown", "index.md")

    let indexContent =
        if File.Exists(indexMarkdownPath) then
            Markdown.ToHtml(File.ReadAllText(indexMarkdownPath))
        else
            ""

    let listOfAllArticlesContent =
        listOfAllArticles
        |> List.map (fun (date, title, link) -> $"""<li>{date}: <a href="{link}">{title}</a></li>""")
        |> String.concat "\n"

    let content =
        $"""
    {indexContent}
    <section class="publications">
        <h1>blog entries</h1>
        <ul>
        {listOfAllArticlesContent}
        </ul>
    </section>
    """

    let finalHtmlContent = generateFinalHtml header footer content "Max Gripe 1982"
    let outputMarkdownFilePath = Path.Combine(Constants.outputDir, "index.html")
    diskUtils.writeFile outputMarkdownFilePath finalHtmlContent

[<EntryPoint>]
let main argv =

    if not (Directory.Exists(Constants.markdownDir)) then
        printfn "Markdown directory does not exist : %s" Constants.markdownDir
        failwith "Markdown directory not found"

    if not (Directory.Exists(Constants.outputDir)) then
        Directory.CreateDirectory(Constants.outputDir)
        |> ignore

    let header = diskUtils.readFile (Path.Combine(Constants.partialsDir, "header.inc"))
    let footer = diskUtils.readFile (Path.Combine(Constants.partialsDir, "footer.inc"))

    let markdownFiles = Directory.GetFiles(Constants.markdownDir, "*.md")

    let articleFiles =
        markdownFiles
        |> Array.filter (fun file -> isArticle (file))

    let listOfAllArticles =
        articleFiles
        |> Array.map (fun file ->
            let date = Path.GetFileNameWithoutExtension(file)

            let title =
                File.ReadAllLines(file)
                |> Array.tryFind (fun line -> line.StartsWith("# "))
                |> Option.defaultValue "# No Title"
                |> fun title -> title.TrimStart('#').Trim()

            let urlFriendlyTitle = urlUtils.toUrlFriendly (title)
            (date, title, $"{urlFriendlyTitle}.html"))
        |> Array.sortByDescending (fun (date, _, _) -> date)
        |> Array.toList

    let createArticlePages () =
        articleFiles
        |> Array.iter (fun file -> createPage header footer file)

    let createOtherPages () =
        markdownFiles
        |> Array.filter (fun file -> not (isArticle (file)))
        |> Array.filter (fun file -> Path.GetFileName(file) <> "index.md")
        |> Array.iter (fun file -> createPage header footer file)

    createIndexPage header footer listOfAllArticles
    createArticlePages ()
    createOtherPages ()

    diskUtils.copyFilesToOutput Constants.fontDir "*.woff2"
    diskUtils.copyFilesToOutput Constants.cssDir "*.css"
    diskUtils.copyImagesToOutput ()

    0
