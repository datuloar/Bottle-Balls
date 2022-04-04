public interface IViewport
{
    IStartWindow GetStartWindow();
    IPlayWindow GetPlayWindow();
    IDefeatWindow GetDefeatWindow();
    IVictoryWindow GetVictoryWindow();
}
