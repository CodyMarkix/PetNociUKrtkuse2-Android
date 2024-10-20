public class SaveFile
{
    public int night { get; set; }
    public int started { get; set; }
    public int badStars { get; set; }

    public SaveFile(int night, int started, int badStars) {
        this.night = night;
        this.started = started;
        this.badStars = badStars;
    }
}
