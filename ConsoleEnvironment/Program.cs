using ConsoleEnvironment;
using ConsoleEnvironment.Models;
using ConsoleEnvironment.Sorting;
using ConsoleEnvironment.Sorting.Impls;

bool IsGreaterInt(int x, int y) => x > y;

var sorting = new ISorting<int>[]
{
    new BubbleSorting<int>(IsGreaterInt),
    new InsertionSorting<int>(IsGreaterInt),
    new SelectionSorting<int>(IsGreaterInt),
    new ShakerSorting<int>(IsGreaterInt)
}.ChooseOne();

var settingsFilePath = args.Length >= 1 ? args[0] : "./appsettings.json"; 
var settings = Settings.Open(new FileInfo(settingsFilePath));

var randomArray = Generator.GenerateList(
    settings.LengthRange ?? new MyRange(20, 101),
    rnd => rnd.Next(settings.NumberRange?.Min ?? -100, settings.NumberRange?.Max ?? 101)
);
Console.ReadLine();
randomArray.WriteTo(Console.Out);

var sortedArray = sorting.Run(randomArray);
sortedArray.WriteTo(Console.Out);

using var client = new RestClient(settings);

await client.PostResult(new SortingResult
{
    RandomArray = randomArray.ToArray(),
    SortedArray = sortedArray.ToArray()
});
