# libScreenshot
`libScreenshot` is a C# library that provides methods for capturing screenshots of the desktop.
## Features
- Capture screenshots of the entire desktop.
- Capture screenshots of specified regions.
- Save screenshots in various formats (e.g., PNG, JPEG).
- Easily integrate screenshot capture into your C# projects.
## Usage
`libScreenshot` offers a range of methods for capturing and saving screenshots.
### Capture a Full Desktop Screenshot
```csharp
Screenshot.Take();
```
This method captures a screenshot of the entire desktop and saves it in PNG format in the "My Pictures" folder.
### Capture a Full Desktop Screenshot and Specify Filename
```csharp
Screenshot.Take("screenshot.png");
```
Capture the desktop and save it with a custom filename ("screenshot.png").
### Capture a Full Desktop Screenshot with Custom Format
```csharp
Screenshot.Take("screenshot.jpg", ImageFormat.Jpeg);
```
Capture the desktop and save it in a specified format (e.g., JPEG).
### Capture a Region Screenshot
```csharp
Screenshot.Take("region.png", width, height);
```
Capture a specified region of the desktop and save it in PNG format.
### Capture a Region Screenshot with Custom Format
```csharp
Screenshot.Take("region.jpg", width, height, ImageFormat.Jpeg);
```
Capture a region of the desktop and save it in a specified format.
## Examples
Example 1:
```csharp
using System;
using libScreenshot;

namespace Example1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Press enter to take a screenshot...");
            Console.ReadLine();
            Screenshot.Take();
            Console.WriteLine($"Screenshot saved in {Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)} folder.");
            Console.Write("Press enter to exit...");
            Console.ReadLine();
        }
    }
}
```
Example 2:
```csharp
using System;
using libScreenshot;

namespace Example2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Press enter to take a screenshot...");
            Console.ReadLine();
            Screenshot.Take("ss1.jpg", 1280, 720);
            Console.WriteLine("Screenshot saved!");
            Console.Write("Press enter to exit...");
            Console.ReadLine();
        }
    }
}
```
## How to Use
1.  Include the `libScreenshot` namespace in your C# project.
2.  Use the provided methods to capture and save screenshots as needed.
## Requirements
- .NET Framework 4.8
## Contribution
Contributions to improve or extend `libScreenshot` are welcome. Feel free to open an issue or submit a pull request.
## License
This project is licensed under the [MIT License](https://github.com/korayustundag/libScreenshot/blob/main/LICENSE).
