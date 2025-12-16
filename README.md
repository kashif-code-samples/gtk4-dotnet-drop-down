# Drop Down with GTK4 and .NET
## Project Setup
Let's start by installing/updating the `dotnet new` [GTK4 .NET Project Template] (https://github.com/kashif-code-samples/gtk4-dotnet-template).  

After making sure we have the new project template available in `dotnet new list`. We can proceed to create our project.  

Let's create a directory for the project and create project structure using following commands
```shell
mkdir gtk4-dotnet-drop-down
cd gtk4-dotnet-drop-down
dotnet new gtk4-app -p:n DropDown
```

Now we can run our application by executing:
```shell
dotnet run --project DropDown/DropDown.csproj
```
At this moment it would display a window with `Hello, world!`.
<figure>
  <a href="images/01-initial-window.png"><img src="images/01-initial-window.png"></a>
  <figcaption>Hello World Window</figcaption>
</figure>


## Source
Source code for the demo application is hosted on GitHub in [gtk4-dotnet-drop-down](https://github.com/kashif-code-samples/gtk4-dotnet-drop-down) repository.

## References
In no particular order
* [GTK](https://www.gtk.org/)
* [GTK Installation](https://www.gtk.org/docs/installations/)
* [.NET](https://dotnet.microsoft.com/en-us/)
* [.NET Download](https://dotnet.microsoft.com/en-us/download)
* [GTK4 project template] (https://github.com/kashif-code-samples/gtk4-dotnet-template)
* [Gir.Core](https://github.com/gircore/gir.core)
* [Gir.Core Gtk-4.0 Samples](https://github.com/gircore/gir.core/tree/main/src/Samples/Gtk-4.0)
* And many more
