module SkunkUtils

module Config =
    open System.IO

    let sourceDir = __SOURCE_DIRECTORY__

    let markdownDir = Path.Combine(sourceDir, "markdown-blog")
    let htmlDir = Path.Combine(sourceDir, "html")
    let outputDir = Path.Combine(sourceDir, "skunk-html-output")

    let cssDir = Path.Combine(sourceDir, "css")
    let outputCssDir = Path.Combine(outputDir, "css")

    let fontsDir = Path.Combine(sourceDir, "fonts")
    let outputFontsDir = Path.Combine(outputDir, "fonts")

    let imagesDir = Path.Combine(markdownDir, "images")
    let outputImagesDir = Path.Combine(outputDir, "images")

    let assetsDir = Path.Combine(sourceDir, "assets")
    let outputAssetsDir = Path.Combine(outputDir, "assets")

    let scriptsDir = Path.Combine(sourceDir, "scripts")
    let outputScriptsDir = Path.Combine(outputDir, "scripts")

    let frontPageMarkdownFileName = "index.md"

module Disk =
    open System.IO

    let readFile (path: string) =
        path
        |> File.Exists
        |> function
            | true -> File.ReadAllText(path)
            | false -> ""

    let writeFile (path: string) (content: string) =
        File.WriteAllText(path, content)
        printfn $"Generated: {Path.GetFileName path} -> {path}\n"

    let copyFolderToOutput (sourceFolder: string) (destinationFolder: string) =
        if not (Directory.Exists(sourceFolder)) then
            printfn $"Source folder does not exist: {sourceFolder}"
        else
            if not (Directory.Exists(destinationFolder)) then
                Directory.CreateDirectory(destinationFolder)
                |> ignore

            Directory.GetFiles(sourceFolder)
            |> Array.iter (fun file ->
                let fileName = Path.GetFileName(file)
                let destFile = Path.Combine(destinationFolder, fileName)
                printfn $"Copying: {fileName} -> {destFile}"
                File.Copy(file, destFile, true))

module Url =
    open System.Text.RegularExpressions

    let toUrlFriendly (input: string) =
        input.ToLowerInvariant()
        |> fun text -> Regex.Replace(text, @"[^\w\s]", "") // Remove all non-alphanumeric characters
        |> fun text -> Regex.Replace(text, @"\s+", "-") // Replace spaces with hyphens