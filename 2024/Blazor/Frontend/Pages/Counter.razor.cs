namespace Application.Frontend.Pages;

public partial class Counter
{
    private int currentCount = 0;
    private string Name { get; set; } = string.Empty;

    protected override void OnInitialized()
    {
        Name = "Tom";
    }
    
    private void IncrementCount()
    {
        currentCount++;
    }
}