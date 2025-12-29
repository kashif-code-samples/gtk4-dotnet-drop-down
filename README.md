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

## Simple DropDown
Let's start with simple DropDown. First we need to add a referce of `GirCore.GObject-2.0.Integration` to our sample project. We need this to use `GObject.SubClass` attribute that would generate boilerplate code for our inherited window.  

Next lets add a class for our window.
```csharp
[GObject.Subclass<Gtk.ApplicationWindow>]
public partial class WithStringList
{
    partial void Initialize()
    {
        // initialize all members
    }
}
```

With our window class added, let's update `Program.cs` to show the new window. Only showing new code for brevity.
```csharp
application.OnActivate += (sender, args) =>
{
    var buttonShowWithStringList = CreateButton("With StringList");
    buttonShowWithStringList.OnClicked += (_, _) => new WithStringList().Show();
    ... 
    
    var gtkBox = Gtk.Box.New(Gtk.Orientation.Vertical, 0);
    gtkBox.Append(buttonShowWithStringList);
    
    ...
    
    window.Child = gtkBox;
}

static Gtk.Button CreateButton(string label)
{
    var button = Gtk.Button.New();
    button.Label = label;
    button.SetMarginTop(12);
    button.SetMarginBottom(12);
    button.SetMarginStart(12);
    button.SetMarginEnd(12);
    return button;
}
```

Next let's add and a label and a dropdown in `WithStringList`
```csharp
    private Gtk.Label _labelSelected;
    private Gtk.DropDown _dropDown;
```
And then update the `Initialize` method to initialize label and dropdown.
```csharp
    partial void Initialize()
    {
        Title = "DropDown With StringList";
        SetDefaultSize(300, 300);
        
        _labelSelected = Gtk.Label.New("Selected: 1 minute");
        _labelSelected.SetMarginTop(12);
        _labelSelected.SetMarginBottom(12);
        _labelSelected.SetMarginStart(12);
        _labelSelected.SetMarginEnd(12);

        var stringList = Gtk.StringList.New(["1 minute", "2 minutes", "5 minutes", "15 minutes", "30 minutes"]);
        _dropDown = new Gtk.DropDown();
        _dropDown.SetModel(stringList);
        _dropDown.SetSelected(0);
        _dropDown.SetMarginTop(12);
        _dropDown.SetMarginBottom(12);
        _dropDown.SetMarginStart(12);
        _dropDown.SetMarginEnd(12);
        
        Gtk.DropDown.SelectedPropertyDefinition.Notify(
            _dropDown,
            (_, _) =>
            {
                var selectedItem = (Gtk.StringObject)_dropDown.SelectedItem!;
                var interval = selectedItem.GetString();
                _labelSelected.SetLabel($"Selected: {interval}");
            });
        
        var gtkBox = Gtk.Box.New(Gtk.Orientation.Vertical, 0);
        gtkBox.Append(_labelSelected);
        gtkBox.Append(_dropDown);

        Child = gtkBox;
    }
```
Here interesting part is that we create a `StringList` with the values that will be displayed in the DropDown. Then we set the model of DropDown to the created StringList. DropDown knows how to work with StringList. Finally we setup selected property changed handler of our DropDown and set the selected value in the label.

Following screenshots show the initial, dropdown and selection for simple DropDown.
<figure>
  <a href="images/03-string-list-initial.png"><img src="images/03-string-list-initial.png"></a>
  <figcaption>With StringList Initial</figcaption>
</figure>

<figure>
  <a href="images/04-string-list-dropdown.png"><img src="images/04-string-list-dropdown.png"></a>
  <figcaption>With StringList DropDown</figcaption>
</figure>

<figure>
  <a href="images/05-string-list-selected.png"><img src="images/05-string-list-selected.png"></a>
  <figcaption>With StringList Selected</figcaption>
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
* [GTK DropDown](https://docs.gtk.org/gtk4/class.DropDown.html)
* [GTK4 DropDown Python Example](https://github.com/ksaadDE/GTK4PythonExamples/blob/main/DropDown.md)
* And many more
