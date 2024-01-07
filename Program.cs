using Newtonsoft.Json.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using UAssetEditor;
using static System.Runtime.InteropServices.JavaScript.JSType;

Console.Write("Enter the search path for the uasset > ");
var file = Console.ReadLine().Replace("\"", string.Empty);
var uasset = new ZenAsset(file);
uasset.ReadHeader();
var end = uasset.ReadBytes((int)(uasset.BaseStream.Length - uasset.Position));

Console.Write("Enter the replace path for the uasset > ");
var file1 = Console.ReadLine().Replace("\"", string.Empty);
var uasset1 = new ZenAsset(file1);
uasset1.ReadHeader();
var end1 = uasset.ReadBytes((int)(uasset1.BaseStream.Length - uasset1.Position));

string[] searchAsset = {""};

var names = uasset.NameMap.Strings;
var names1 = uasset1.NameMap.Strings;
int IAMRacist = names[0].Length;

while (true)
{
    
    Console.Clear();

    for (int i = 0; i < names.Count; i++)
    {
        Console.WriteLine($"{i + 1}) '{names.ElementAt(i)}'");
        searchAsset.Append(names[i]);
    }
        

    Console.WriteLine("\nEnter Q to save and compress file exit.");
    Console.Write("Enter the number of the string you want to edit > ");

    string value = names[0].Length.ToString();

    byte[] valueBytes = Encoding.UTF8.GetBytes(value);

    string hexString = Convert.ToHexString(valueBytes);

    Console.WriteLine();
    var numberStr = Console.ReadLine();

    if (numberStr?.ToLower() == "q")
    {
        var writer = new Writer(File.OpenWrite(Path.GetFileNameWithoutExtension(file) + " Edited.uasset"));
        uasset.WriteHeader(writer);
        writer.WriteBytes(end);
        writer.Close();
        string gayNigPath = Path.GetFileNameWithoutExtension(file) + " Edited.uasset";
        string gayNiga = Path.GetFileNameWithoutExtension(file);
        string replaceNiga =  gayNiga.Replace(".uasset", string.Empty);
        byte[] data = File.ReadAllBytes(gayNigPath);

        byte[] getNigBytes = Encoding.UTF8.GetBytes(replaceNiga);

        //byte[] gayBytes = Encoding.UTF8.GetBytes(names[0].Length.ToString());
        int gayValue = names[0].Length;

        string hexValue = gayValue.ToString("X");

        byte hexChanged = Convert.ToByte(hexValue, 16);

        int startOffset = FindStartOfLayoutPattern(data, hexChanged) - 1;


        string hexValue2 = IAMRacist.ToString("X");
        byte hexChanged2 = Convert.ToByte(hexValue2, 16);
        
        int startOffset2 = FindStartOfLayoutPattern(data, hexChanged2) - 1;

        string replace = "";
        string search = "";


        int lastOccurrenceOffset = FindLastOccurrenceOffset(data, gayNiga);
        int gayOccurrenceOffset1 = lastOccurrenceOffset + gayNiga.Length;



        if (lastOccurrenceOffset != -1)
        {
            //Console.WriteLine($"Last occurrence of '{gayNiga}' found at offset: {lastOccurrenceOffset}");
        }
        else
        {
            Console.WriteLine($"Error: '{gayNiga}' not found in the file.");
            return;
        }
        for (int i = startOffset; i < gayOccurrenceOffset1; i++)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(data[i].ToString("X2"));
            string niggaBallsCunt = sb.ToString();
            replace = replace + niggaBallsCunt;

            if (i == gayOccurrenceOffset1)
            {
                break;
            }
        }

        byte[] data1 = File.ReadAllBytes(file);

        for (int i = startOffset2; i < gayOccurrenceOffset1; i++)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(data1[i].ToString("X2"));
            string niggaBallsCunt = sb.ToString();
            search = search + niggaBallsCunt;

            if (i == gayOccurrenceOffset1)
            {
                break;
            }
        }



        byte[] array1 = Enumerable.Range(0, search.Length)
    .Where(x => x % 2 == 0)
    .Select(x => Convert.ToByte(search.Substring(x, 2), 16))
    .ToArray();

        byte[] array2 = Enumerable.Range(0, replace.Length)
    .Where(x => x % 2 == 0)
    .Select(x => Convert.ToByte(replace.Substring(x, 2), 16))
    .ToArray();

        byte[] numArray = File.ReadAllBytes(file);
        int startIndex = 0;
        while (true)
        {
            int num1 = IndexOfBytes(numArray, array1, startIndex);
            if (num1 != -1)
            {
                int num2 = array1.Length - array2.Length;
                for (int index = 0; index < array2.Length; ++index)
                    numArray[num1 + index] = array2[index];
                for (int index = 0; index < num2; ++index)
                    numArray[num1 + array2.Length + index] = 0;

                startIndex = num1 + 1;
            }
            else
                break;
        }


        string path2 = Path.GetDirectoryName(file) + "\\modified_" + Path.GetFileName(file);
        File.WriteAllBytes(path2, numArray);
        Console.WriteLine("String replacement complete. Modified file saved as: " + path2);
        //Console.WriteLine(startOffset);


        string path = path2;

        string[] gayPath = path.Split('/');
        int start = 0;
        string messageBoxPath = "";
        while (true)
        {
            if (start < gayPath.Length)
            {
                byte[] readDecompressBytes = File.ReadAllBytes(gayPath[start]);
                string bytes = System.Text.Encoding.UTF8.GetString(StringEditor.Oodle.Compress(readDecompressBytes));
                string compressedHex = Convert.ToHexString(StringEditor.Oodle.Compress(readDecompressBytes));
                FileInfo info = new FileInfo(path.ToString());
                string gay = info.DirectoryName + $"/{info.Name.Replace(".uasset", "compressed.uasset")}";
                messageBoxPath = gay.ToString();
                var stream = new FileStream(gay.ToString(), FileMode.Create, FileAccess.ReadWrite);
                WriteHexStringToFile(compressedHex, stream);
                stream.Close();
                start = +1;
            }
            if (start == gayPath.Length)
            {
                break;
            }
        }
        break;
    }

    var number = Convert.ToInt32(numberStr);
    Console.Clear();
    
    var old = names[number - 1];

    for (int i = 0; i < names1.Count; i++)
    {
        Console.WriteLine($"[{i + 1}]: {names1.ElementAt(i)}");
    }


    Console.WriteLine("\nTHESE ARE THE REPLACED STRINGS");

    Console.Write("\nEnter the number of the replace string you want to edit > ");

    var numberStr2 = Console.ReadLine();

    var number2 = Convert.ToInt32(numberStr2);


    Console.Clear();

    var oldReplace = names1[number2 - 1];

    Console.WriteLine($"Search string: [{old.Length.ToString()}] {old}\n");

    Console.WriteLine($"Replace String: [{oldReplace.Length.ToString()}] {oldReplace}\n");

    Console.Write("Enter a new string > ");

    var str = Console.ReadLine() ?? "None";




    string searchTogether = old;
    string sT = "";
    if (old.Contains("/"))
    {
        int lastIndex = old.LastIndexOf("/") + 1;

        int lastLength = old.Length;
        string nigga = "";
        for (int i = lastIndex; i < lastLength; i++)
        {

            nigga = nigga + old[i];
            if (lastIndex == lastLength)
            {
                searchTogether = old + nigga;
                break;
            }
            
        }

        sT = nigga;



    }

    string strTogether = str;
    string strT = "";
    if(str.Contains("/"))
    {
        int lastIndex = str.LastIndexOf("/") + 1;
        int lastLength = str.Length;
        string gay = "";
        for (int i = lastIndex; i < lastLength; i++)
        {

            gay = gay + str[i];
            if (lastIndex == lastLength)
            {
                strTogether = str + gay;
                break;
            }

            strT = gay;
            

        }
        
        
        names[number - 1] = oldReplace;

        int doubleOffsetInArray = 0;
        for (int i = 0; i < names.Count; i++)
        {
            if (names[i] == sT)
            {
                doubleOffsetInArray = i;
                int length  = sT.Length;
                int sLength = strT.Length;
                int searchLen = searchTogether.Length;
                int replaceLen = strTogether.Length;
                int gayLength = length - sLength + searchLen - replaceLen;
                int newLen = sLength + gayLength;
                string fuck = "";
                string fuckMe = ""; 

                byte[] data = FromHex("00");
                string s = Encoding.ASCII.GetString(data);
               
                for(int g  = 0; g < gayLength; g ++)
                {
                    fuck = fuck + s;

                    names[i] = strT + fuck;

                    if (g == gayLength)
                    {
                        Console.WriteLine($"\nReplaced '{old}' with '{str}'.");
                        break;
                    }
                }
            }

            
            
        }







    }
    static int FindStartOfLayoutPattern(byte[] searchIn, byte gayNiggaU)
    {

        byte[] layoutStartPattern = new byte[] { 0x00, gayNiggaU, 0x00 };

        for (int i = 1; i < searchIn.Length - layoutStartPattern.Length; i++)
        {

            if (searchIn[i - 1] == 0x00 && searchIn[i] == gayNiggaU && searchIn[i + 1] == 0x00)
            {
                
                return i;
            }
        }

        return -1;
    }

     static int FindLastOccurrenceOffset(byte[] searchIn, string fileNameWithoutExtension)
    {
        byte[] fileNameBytes = Encoding.Default.GetBytes(fileNameWithoutExtension);

        int lastOccurrenceOffset = -1;

        for (int i = 0; i < searchIn.Length - fileNameBytes.Length; i++)
        {
            bool match = true;

            for (int j = 0; j < fileNameBytes.Length; j++)
            {
                if (searchIn[i + j] != fileNameBytes[j])
                {
                    match = false;
                    break;
                }
            }

            if (match)
            {
                lastOccurrenceOffset = i;
            }
        }

        return lastOccurrenceOffset;
    }
    static void WriteHexStringToFile(string hexString, FileStream stream)
    {
        var twoCharacterBuffer = new StringBuilder();
        var oneByte = new byte[1];
        foreach (var character in hexString.Where(c => c != ' '))
        {
            twoCharacterBuffer.Append(character);

            if (twoCharacterBuffer.Length == 2)
            {
                oneByte[0] = (byte)Convert.ToByte(twoCharacterBuffer.ToString(), 16);
                stream.Write(oneByte, 0, 1);
                twoCharacterBuffer.Clear();
            }
        }
    }
    static void FindAndReplaceHexLength(byte[] data, int oldLength, int newLength)
    {
        // Very Smexy
        byte[] oldLengthBytes = BitConverter.GetBytes((ushort)oldLength);
        byte[] newLengthBytes = BitConverter.GetBytes((ushort)newLength);

        int index = 0;

        while ((index = IndexOfBytes(data, oldLengthBytes, index)) != -1)
        {
            // Oooo YAA
            Array.Copy(newLengthBytes, 0, data, index, newLengthBytes.Length);
            
            index += newLengthBytes.Length;
            
        }
    }

    static int IndexOfBytes(byte[] searchIn, byte[] searchFor, int startIndex)
    {
        if (searchIn.Length == 0 || searchFor.Length > searchIn.Length)
            return -1;
        for (int index1 = startIndex; index1 < searchIn.Length - searchFor.Length + 1; ++index1)
        {
            if (searchIn.Skip(index1).Take(searchFor.Length).SequenceEqual(searchFor))
            {
                return index1;
            }
        }
        return -1;
    }


    static byte[] FromHex(string hex)
    {
        hex = hex.Replace("-", "");
        byte[] raw = new byte[hex.Length / 2];
        for (int i = 0; i < raw.Length; i++)
        {
            raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
        }
        return raw;
    }

    int bigLength = 0;
    if(old.Contains("/") && str.Contains("/"))
    {
        bigLength = searchTogether.Length - strTogether.Length;
    }
    int tinylength = 0;
    
    if(!str.Contains("/"))
    {
        tinylength = old.Length - oldReplace.Length;
        //names[number - 1] = str;
    }
    

    Console.WriteLine($"\nReplaced '{old}' with '{str}'.");
    Console.WriteLine("\nPress any key to return to strings...");
    Console.ReadKey();
}