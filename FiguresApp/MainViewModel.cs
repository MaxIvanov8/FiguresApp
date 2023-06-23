using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using GalaSoft.MvvmLight.CommandWpf;

namespace FiguresApp;

public class MainViewModel:INotifyPropertyChanged
{
    private const int CanvasHeight = 500;
    private const int CanvasWidth = 400;
    private const string ProgramMessage = "Program message";
    private FigureTypes _selectedType;

    public FigureTypes SelectedType
    {
        get => _selectedType;
        set
        {
            _selectedType = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<Figure> FiguresCollection { get; }
    public ICommand AddCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand ClearCommand { get; }
    public int Left { get; set; }
    public int Top { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public Brush SelectedColor { get; set; }

    public MainViewModel()
    {
        FiguresCollection = new ObservableCollection<Figure>();
        SelectedColor = Brushes.Black;
        AddCommand = new RelayCommand(AddMethod);
        DeleteCommand = new RelayCommand<Figure>(obj=>FiguresCollection.Remove(obj));
        ClearCommand = new RelayCommand(()=>FiguresCollection.Clear());
    }

    private void AddMethod()
    {
        if(Width==0 || (SelectedType is FigureTypes.Ellipse or FigureTypes.Rectangle && Height==0))
        {
            MessageBox.Show("The figure is not valid", ProgramMessage);
            return;
        }
        var figure = new Figure(Top, Left, Width, Height, SelectedColor, SelectedType);
        if (figure.IsValid(CanvasHeight, CanvasWidth))
            FiguresCollection.Add(figure);
        else
            MessageBox.Show("The figure is out of bounds", ProgramMessage);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}