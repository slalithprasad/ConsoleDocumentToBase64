using System.Text.Json;
using System.Xml.Linq;
using TextCopy;

Console.Write("Enter the path of the document: ");
string? documentPath = Console.ReadLine();

if (!string.IsNullOrEmpty(documentPath) && documentPath.StartsWith("\"") && documentPath.EndsWith("\""))
{
    documentPath = documentPath.Substring(1, documentPath.Length - 2);
}

while (!File.Exists(documentPath))
{
    Console.Write("The file does not exist. Please enter a valid path: ");
    documentPath = Console.ReadLine();

    if (!string.IsNullOrEmpty(documentPath) && documentPath.StartsWith("\"") && documentPath.EndsWith("\""))
    {
        documentPath = documentPath.Substring(1, documentPath.Length - 2);
    }
}

byte[] fileBytes = File.ReadAllBytes(documentPath);
string base64 = Convert.ToBase64String(fileBytes);
string mimeType = GetMimeType(documentPath);

Console.WriteLine("Select output format:");
Console.WriteLine("1. Plain Text (e.g., 'SGVsbG8gd29ybGQ=')");
Console.WriteLine("2. Data URI (e.g., 'data:image/png;base64,SGVsbG8gd29ybGQ=')");
Console.WriteLine("3. CSS Background Image (e.g., 'background-image: url(\"data:image/png;base64,SGVsbG8gd29ybGQ=\");')");
Console.WriteLine("4. HTML Favicon (e.g., '<link rel=\"icon\" href=\"data:image/png;base64,SGVsbG8gd29ybGQ=\">')");
Console.WriteLine("5. HTML Hyperlink (e.g., '<a href=\"data:image/png;base64,SGVsbG8gd29ybGQ=\">Download</a>')");
Console.WriteLine("6. HTML Image (e.g., '<img src=\"data:image/png;base64,SGVsbG8gd29ybGQ=\">')");
Console.WriteLine("7. HTML Iframe (e.g., '<iframe src=\"data:image/png;base64,SGVsbG8gd29ybGQ=\"></iframe>')");
Console.WriteLine("8. JavaScript Image (e.g., 'var img = new Image(); img.src = \"data:image/png;base64,SGVsbG8gd29ybGQ=\";')");
Console.WriteLine("9. JavaScript Popup (e.g., 'window.open(\"data:image/png;base64,SGVsbG8gd29ybGQ=\");')");
Console.WriteLine("10. JSON (e.g., '{ \"image\": { \"mime\": \"image/png\", \"data\": \"SGVsbG8gd29ybGQ=\" } }')");
Console.WriteLine("11. XML (e.g., '<image mime=\"image/png\">SGVsbG8gd29ybGQ=</image>')");
Console.Write("Enter choice (1-11): ");
string? choice = Console.ReadLine();

HashSet<string> validChoices = new() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11" };

while (string.IsNullOrEmpty(choice) || !validChoices.Contains(choice))
{
    Console.Write("Invalid choice! Please enter a valid choice (1-11): ");
    choice = Console.ReadLine();
}

string output = choice switch
{
    "1" => base64,
    "2" => $"data:{mimeType};base64,{base64}",
    "3" => $"background-image: url('data:{mimeType};base64,{base64}');",
    "4" => $"<link rel=\"icon\" href=\"data:{mimeType};base64,{base64}\">",
    "5" => $"<a href=\"data:{mimeType};base64,{base64}\">Download</a>",
    "6" => $"<img src=\"data:{mimeType};base64,{base64}\">",
    "7" => $"<iframe src=\"data:{mimeType};base64,{base64}\"></iframe>",
    "8" => $"var img = new Image(); img.src = 'data:{mimeType};base64,{base64}';",
    "9" => $"window.open('data:{mimeType};base64,{base64}');",
    "10" => JsonSerializer.Serialize(new { image = new { mime = mimeType, data = base64 } }, new JsonSerializerOptions { WriteIndented = true }),
    "11" => new XElement("image", new XAttribute("mime", mimeType), base64).ToString(),
    _ => "Invalid choice!"
};

ClipboardService.SetText(output);
Console.WriteLine("\nOutput is copied to clipboard! Use Ctrl+V or Cmd+V to paste it.");

string GetMimeType(string filePath)
{
    string extension = Path.GetExtension(filePath).ToLower();
    return extension switch
    {
        ".txt" => "text/plain",
        ".csv" => "text/csv",
        ".doc" => "application/msword",
        ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
        ".xls" => "application/vnd.ms-excel",
        ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
        ".ppt" => "application/vnd.ms-powerpoint",
        ".pptx" => "application/vnd.openxmlformats-officedocument.presentationml.presentation",
        ".odt" => "application/vnd.oasis.opendocument.text",
        ".ods" => "application/vnd.oasis.opendocument.spreadsheet",
        ".odp" => "application/vnd.oasis.opendocument.presentation",
        ".rtf" => "application/rtf",
        ".pdf" => "application/pdf",
        ".jpg" or ".jpeg" => "image/jpeg",
        ".png" => "image/png",
        ".gif" => "image/gif",
        ".bmp" => "image/bmp",
        ".tiff" or ".tif" => "image/tiff",
        ".svg" => "image/svg+xml",
        ".webp" => "image/webp",
        ".html" or ".htm" => "text/html",
        ".css" => "text/css",
        ".js" => "application/javascript",
        ".json" => "application/json",
        ".xml" => "application/xml",
        ".zip" => "application/zip",
        ".rar" => "application/vnd.rar",
        ".7z" => "application/x-7z-compressed",
        ".tar" => "application/x-tar",
        ".gz" => "application/gzip",
        ".mp3" => "audio/mpeg",
        ".wav" => "audio/wav",
        ".ogg" => "audio/ogg",
        ".mp4" => "video/mp4",
        ".avi" => "video/x-msvideo",
        ".mov" => "video/quicktime",
        ".mkv" => "video/x-matroska",
        ".cs" => "text/plain",
        ".java" => "text/x-java-source",
        ".py" => "text/x-python",
        ".cpp" => "text/x-c++src",
        ".c" => "text/x-csrc",
        ".php" => "application/x-httpd-php",
        ".sh" => "application/x-sh",
        ".bat" => "application/x-msdos-program",
        _ => "application/octet-stream"
    };
}