using Saber;

var pathWithEnv = @"%USERPROFILE%\Desktop\output.txt";
var filePath = Environment.ExpandEnvironmentVariables(pathWithEnv);

ListRandom listToSerialize = new ListRandom();

int.TryParse(Console.ReadLine(), out int numberOfElements);

for (int i = 0; i < numberOfElements; ++i)
{
    listToSerialize.AddNewNode($"{(char)(i + 65)}");
}

listToSerialize.Serialize(new FileStream(filePath, FileMode.Create));

ListRandom listToDeSerialize = new ListRandom();
listToDeSerialize.Deserialize(new FileStream(filePath, FileMode.Open));