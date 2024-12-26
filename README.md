
[![Azure Static Web Apps CI/CD](https://github.com/MaxGripe/maxgripe.github.io/actions/workflows/main.yml/badge.svg)](https://github.com/MaxGripe/maxgripe.github.io/actions/workflows/main.yml)
![GitHub repo size](https://img.shields.io/github/repo-size/MaxGripe/maxgripe.github.io)
![GitHub License](https://img.shields.io/github/license/MaxGripe/maxgripe.github.io)
![GitHub Created At](https://img.shields.io/github/created-at/MaxGripe/maxgripe.github.io)
![GitHub forks](https://img.shields.io/github/forks/MaxGripe/maxgripe.github.io)
![GitHub Repo stars](https://img.shields.io/github/stars/MaxGripe/maxgripe.github.io)

# Max Gripe's Homepage
Welcome to my homepage! It serves as a platform for me to share my links and thoughts. At the moment, I've got a really cool domain https://max.gripe linked to this site, but I won't live forever, so the address https://maxgripe.github.io might be more future-proof.

This page was generated using a Markdown blog generator. Details can be found below.

## SkunkHTML setup
Your own Markdown blog on GitHub in under 60 seconds:

1. Fork [SkunkHTML](https://github.com/MaxGripe/skunk-html) repository on GitHub.
2. Enable GitHub Pages in the repository settings (choose GitHub Actions as the source).
3. Done! Your blog is online! Example: https://max.gripe/skunk-html/

Upload Markdown (.md) files to publish new posts.

## How it works

When a Markdown (.md) file is created and placed in the `/markdown-blog/` folder, the rest happens automatically. GitHub Actions detects changes pushed to the repository, triggers the build process, and deploys the updated site.

## Some technical details

- This code automatically generates a website on GitHub Pages using Markdown files as the source. 

- Blog articles and other content are written in Markdown, allowing for easy content creation and management. These Markdown files are automatically converted to HTML during the build process using F# and the [FSharp.Formatting](https://github.com/fsprojects/FSharp.Formatting) library.

- The deployment process is fully automated using [GitHub Actions](https://github.com/features/actions). Any changes to this repository are immediately reflected on the live site.

- [Giscus](https://giscus.app/) comment system is supported.

- The repository is 100% ready to work directly on GitHub without the need to download it locally. Simply fork it to create your own website. Don't forget to enable GitHub Pages in repo! (Settings ➔ Pages ➔ Build and deployment: "GitHub Actions").

## Folder structure

- `/`: Root directory of the project.

  - `.github/workflows/`: GitHub Actions workflow file. Responsible for automatically generating final website on GitHub Pages
  - `assets/`: Files used across the entire site, such as the avatar, favicon, and other shared resources.
  - `css/`: CSS files for the site.
  - `fonts/`: Custom fonts go here.
  - `html/`: HTML fragments used throughout the site, such as the title and footer.
  - `markdown-blog/`: Directory containing the Markdown files for articles and other content. Blog articles are identified by file names that start with a digit.
    - `images/`:  Images used in the articles.
  - `scripts/`: Syntax highlighting script and optionally other custom scripts..
  - `skunk-html-output/`: Directory that will be created during the build process, with the generated HTML files.

- `LICENSE`: License file for the project.
- `Program.fs`: F# program that handles the generation of HTML from Markdown
- `README.md`: This file. 
- `skunk-html.fsproj`: Project file

## Contributing

Feel free to open [issues](https://github.com/MaxGripe/skunk-html/issues) or submit pull requests if you have suggestions or improvements for the site. Contributions are always welcome!

## License

This project is licensed under the terms of the [Unlicense](https://en.wikipedia.org/wiki/Unlicense).

It also uses some external stuff, each with its own license:

- [MVP.css](https://github.com/andybrewer/mvp) for styling
- [microlight.js](https://github.com/asvd/microlight) for syntax highlighting
- [FSharp.Formatting](https://github.com/fsprojects/FSharp.Formatting) library for Markdown processing
- [JetBrains Mono](https://github.com/JetBrains/JetBrainsMono) typeface
