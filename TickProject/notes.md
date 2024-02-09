# System Namespace

## Console Class

- **`Console.WriteLine(string value)`**:

  - Writes the specified string value followed by the current line terminator to the standard output stream.

- **`Console.ReadLine()`**:
  - Reads the next line of characters from the standard input stream.

## String Class

- **`string.ToString()`**:
  - Returns a string representation of the object.

## Exception Class

- **`InvalidDataException`**:
  - Represents the exception that is thrown when invalid data is encountered.

# System.IO Namespace

## File Class

- **`File.Exists(string path)`**:

  - Determines whether the specified file exists.

- **`File.WriteAllLines(string path, IEnumerable<string> contents)`**:

  - Creates a new file, writes a collection of strings to the file, and then closes the file.

- **`File.WriteAllLines(string path, string[] contents)`**:

  - Overload of `WriteAllLines` that accepts an array of strings.

- **`File.AppendAllLines(string path, IEnumerable<string> contents)`**:

  - Appends a collection of strings to the end of a file, creating the file if it does not exist.

- **`File.ReadAllText(string path)`**:

  - Opens a text file, reads all lines of the file, and then closes the file.

- **`File.ReadAllLines(string path)`**:
  - Reads all lines of the file.

## StreamReader Class

- **`StreamReader(string path)`**:
  - Initializes a new instance of the `StreamReader` class for the specified file.

## Path Class

- **`Path.Combine(string path1, string path2)`**:
  - Combines two strings into a path.

# System.Xml.Serialization Namespace

## XmlSerializer Class

- **`XmlSerializer(Type type)`**:

  - Initializes a new instance of the `XmlSerializer` class that can serialize objects of the specified type.

- **`Serialize(TextWriter textWriter, object o)`**:

  - Serializes the specified object and writes the XML document to a TextWriter.

- **`Deserialize(TextReader textReader)`**:

  - Deserializes the XML document contained by the specified TextReader.

```C#
[XmlElement("Person")]
public List<Person> Persons { get; set; }
```

```C#
static void AppendToFile(Timer timer, string path)
{
	// 1) deserialize list or create if not exist
    List<Timer> existingTimers = DeserializeXML(path) ?? new List<Timer>();

	// 2) add new person to existing or new list (depending on outcome of step 1)
    existingTimers.Add(timer);

	// 3) reserialize existing or new list with new person in it now
    Serialize(existingTimers, path);
}
```
