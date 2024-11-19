
[![Azure Static Web Apps CI/CD](https://github.com/MaxGripe/maxgripe.github.io/actions/workflows/main.yml/badge.svg)](https://github.com/MaxGripe/maxgripe.github.io/actions/workflows/main.yml)
![GitHub repo size](https://img.shields.io/github/repo-size/MaxGripe/maxgripe.github.io)
![GitHub License](https://img.shields.io/github/license/MaxGripe/maxgripe.github.io)
![GitHub Created At](https://img.shields.io/github/created-at/MaxGripe/maxgripe.github.io)
![GitHub forks](https://img.shields.io/github/forks/MaxGripe/maxgripe.github.io)
![GitHub Repo stars](https://img.shields.io/github/stars/MaxGripe/maxgripe.github.io)

# Max Gripe's Homepage
Welcome to my homepage! It serves as a platform for me to share my links and thoughts. At the moment, I've got a really cool domain https://max.gripe linked to this site, but I won't live forever, so the address https://maxgripe.github.io might be more future-proof.

## Some technical details:

- This website is hosted on GitHub Pages. 

- Articles and other content are written in Markdown, allowing for easy content creation and management. These Markdown files are automatically converted to HTML during the build process using [F#](https://fsharp.org/) and the [FSharp.Formatting](https://fsprojects.github.io/FSharp.Formatting/) library.

- The deployment process is fully automated using [GitHub Actions](https://github.com/features/actions). Any changes to this repository are immediately reflected on the live site.

- This site also uses the [giscus](https://giscus.app/) comment system.

## Folder structure

- `/`: Root directory of the project.

  - `.github/workflows/`: GitHub Actions workflow file.

  - `css/`: CSS file for the site.
  - `markdown/`: Directory containing the Markdown files for articles and other content. Articles are identified by the presence of a digit (date) in the file name.
    - `images/`:  Images used in the articles.
  - `partials/`: Reusable HTML snippets like `header.inc` and `footer.inc`.
  - `output/`: Directory that will be created during the build process, with the generated HTML files.
- `HtmlGenerator.fsproj`: Project file

- `LICENSE`: License file for the project.  

- `Program.fs`: F# program that handles the generation of HTML from Markdown 

- `README.md`: This file.



## How it works

When I write an article in Markdown and place it in the `/markdown/` folder, the rest happens automatically. GitHub Actions detects changes pushed to the repository, triggers the build process, and deploys the updated site.

## Contributing

Feel free to open issues or submit pull requests if you have suggestions or improvements for the site. Contributions are always welcome! 😁

## License

This project is licensed under the terms of the [Unlicense](https://en.wikipedia.org/wiki/Unlicense).


