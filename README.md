# ConsoleDocumentToBase64

A simple **C#** console-based application that converts any document to Base64 format and provides multiple output formats.

## Features
- Convert files to Base64 format
- Supports multiple output formats:
  - Plain Text
  - Data URI
  - CSS Background Image
  - HTML Favicon
  - HTML Hyperlink
  - HTML Image
  - HTML Iframe
  - JavaScript Image
  - JavaScript Popup
  - JSON
  - XML
- Supports various file types, including text, images, documents, and code files.

## Prerequisites  
- Download and Install [.NET 9.0 SDK](https://dotnet.microsoft.com/en-us/download)

## Installation
1. Clone the repository:
   ```sh
   git clone https://github.com/yourusername/ConsoleDocumentToBase64.git
   ```

2. Install the required NuGet packages:  
    ```bash
    dotnet restore
    ```

3. Navigate to the project folder:
   ```sh
   cd ConsoleDocumentToBase64
   ```
4. Build and run the application:
   ```sh
   dotnet run
   ```

## Usage
1. Run the application.
2. Enter the file path of the document you want to convert.
3. Choose an output format from the list.

### Output Formats & Examples
| # | Format | Example Output |
|--------|--------|---------------|
| 1 | **Plain Text** | `SGVsbG8gd29ybGQ=` |
| 2 | **Data URI** | `data:image/png;base64,SGVsbG8gd29ybGQ=` |
| 3 | **CSS Background Image** | `background-image: url("data:image/png;base64,SGVsbG8gd29ybGQ=");` |
| 4 | **HTML Favicon** | `<link rel="icon" href="data:image/png;base64,SGVsbG8gd29ybGQ=">` |
| 5 | **HTML Hyperlink** | `<a href="data:image/png;base64,SGVsbG8gd29ybGQ=">Download</a>` |
| 6 | **HTML Image** | `<img src="data:image/png;base64,SGVsbG8gd29ybGQ=">` |
| 7 | **HTML Iframe** | `<iframe src="data:image/png;base64,SGVsbG8gd29ybGQ="></iframe>` |
| 8 | **JavaScript Image** | `var img = new Image(); img.src = "data:image/png;base64,SGVsbG8gd29ybGQ=";` |
| 9 | **JavaScript Popup** | `window.open("data:image/png;base64,SGVsbG8gd29ybGQ=");` |
| 10 | **JSON** | `{ "image": { "mime": "image/png", "data": "SGVsbG8gd29ybGQ=" } }` |
| 11 | **XML** | `<image mime="image/png">SGVsbG8gd29ybGQ=</image>` |


## Clipboard Integration
The output is automatically copied to the clipboard so you can paste it directly.

All credits to https://github.com/CopyText/TextCopy

---

**Convert your documents to Base64 in seconds!** 🚀
