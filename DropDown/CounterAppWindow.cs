
namespace DropDown;

[GObject.Subclass<Gtk.ApplicationWindow>]
public partial class CounterAppWindow
{
    private int _counter = 0;
    private Gtk.Label _labelCounter;
    private Gtk.Button _buttonIncrease;
    private Gtk.Button _buttonDecrease;

    public CounterAppWindow(Gtk.Application application) : this()
    {
        Application = application;
    }

    partial void Initialize()
    {
        Title = "GTK DropDown App";
        SetDefaultSize(300, 300);

        _labelCounter = Gtk.Label.New(_counter.ToString());
        _labelCounter.SetMarginTop(12);
        _labelCounter.SetMarginBottom(12);
        _labelCounter.SetMarginStart(12);
        _labelCounter.SetMarginEnd(12);

        _buttonIncrease = Gtk.Button.New();
        _buttonIncrease.Label = "Increase";
        _buttonIncrease.SetMarginTop(12);
        _buttonIncrease.SetMarginBottom(12);
        _buttonIncrease.SetMarginStart(12);
        _buttonIncrease.SetMarginEnd(12);
        _buttonIncrease.OnClicked += (_, _) =>
        {
            _counter++;
            _labelCounter.SetLabel(_counter.ToString());
        };

        _buttonDecrease = Gtk.Button.New();
        _buttonDecrease.Label = "Decrease";
        _buttonDecrease.SetMarginTop(12);
        _buttonDecrease.SetMarginBottom(12);
        _buttonDecrease.SetMarginStart(12);
        _buttonDecrease.SetMarginEnd(12);
        _buttonDecrease.OnClicked += (_, _) =>
        {
            _counter--;
            _labelCounter.SetLabel(_counter.ToString());
        };

        var gtkBox = Gtk.Box.New(Gtk.Orientation.Vertical, 0);
        gtkBox.Append(_labelCounter);
        gtkBox.Append(_buttonIncrease);
        gtkBox.Append(_buttonDecrease);

        Child = gtkBox;
    }
}
