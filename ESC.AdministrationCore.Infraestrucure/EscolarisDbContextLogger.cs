using static System.Environment;

namespace ESC.AdministrationCore.Infraestructure;

public class EscolarisDbContextLogger
{
  public static void WriteLine(string message)
  {
    string path = Path.Combine(GetFolderPath(
      SpecialFolder.DesktopDirectory), "escolarisdblog.txt");

    StreamWriter textFile = File.AppendText(path);
    textFile.WriteLine(message);
    textFile.Close();
  }
}
