
[![Azure Static Web Apps CI/CD](https://github.com/MaxGripe/max-gripe-homepage/actions/workflows/main.yml/badge.svg)](https://github.com/MaxGripe/max-gripe-homepage/actions/workflows/main.yml)
![GitHub repo size](https://img.shields.io/github/repo-size/MaxGripe/max-gripe-homepage)
![GitHub License](https://img.shields.io/github/license/MaxGripe/max-gripe-homepage)
![GitHub Created At](https://img.shields.io/github/created-at/MaxGripe/max-gripe-homepage)
![GitHub forks](https://img.shields.io/github/forks/MaxGripe/max-gripe-homepage)
![GitHub Repo stars](https://img.shields.io/github/stars/MaxGripe/max-gripe-homepage)

# Max Gripe's Homepage
Welcome to my [homepage](https://max.gripe/)! It serves as a platform for me to share my links and thoughts.

## Some technical details:

- This website is hosted on [Azure](https://azure.microsoft.com/) using free plan. 

- Articles and other content are written in Markdown, allowing for easy content creation and management. These Markdown files are automatically converted to HTML during the build process using [F#](https://fsharp.org/) and the [FSharp.Formatting](https://fsprojects.github.io/FSharp.Formatting/) library.

- The deployment process is fully automated using [GitHub Actions](https://github.com/features/actions). Any changes to this repository are immediately reflected on the live site.

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

When I write an article in Markdown and place it in the `/markdown/` folder, the rest happens automatically. GitHub Actions detects changes pushed to the repository, triggers the build process, and deploys the updated site to Azure Static Web Apps.

## Contributing

Feel free to open issues or submit pull requests if you have suggestions or improvements for the site. Contributions are always welcome! 😁

## License

This project is licensed under the terms of the [Unlicense](https://en.wikipedia.org/wiki/Unlicense).


