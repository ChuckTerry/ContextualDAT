using System.IO;

class ContextualDatMenu {
    static void Main(string[] args) {
        string rootName, path;
        // We should always recieve one argument
        if (args.Length != 1) {
            return;
        }
        path = args[0];
        // The argument should always be an existing directory
        if (!Directory.Exists(path)) {
            return;
        }
        rootName = path + "\\" + DetermineFileName(path);
        // The proposed directory should not currently exist
        if (!Directory.Exists(rootName)) {
            BuildSitesDirectory(rootName);
        }
    }

    public static void BuildSitesDirectory(string path) {
        string modelFolderA = path + "\\model-a";
        string modelFolderB = path + "\\model-b";
        // Create the parent directory
        Directory.CreateDirectory(path);
        // Create the Model A subdirectoy and files
        Directory.CreateDirectory(modelFolderA);
        File.Create(modelFolderA + "\\index.html");
        File.Create(modelFolderA + "\\styles.css");
        File.Create(modelFolderA + "\\script.js");
        // Create the Model B subdirectoy and files
        Directory.CreateDirectory(modelFolderB);
        File.Create(modelFolderB + "\\index.html");
        File.Create(modelFolderB + "\\styles.css");
        File.Create(modelFolderB + "\\script.js");
    }

    public static string DetermineFileName(string path) {
        int identifier = 1;
        string[] subdirectoryEntries = Directory.GetDirectories(path);
        // Explicit upper limit to prevent any accidental infinite loops
        while(identifier < 1000) {
            string fileName = "\\website " + Convert.ToString(identifier);
            string currentName = path + fileName;
            int pos = Array.IndexOf(subdirectoryEntries, currentName);
            // Once we find a "website #" that doesn't exist, break out of the loop.
            if (pos == -1) {
                break;
            }
            identifier++;
        }
        return "\\website " + Convert.ToString(identifier);
    }
}
