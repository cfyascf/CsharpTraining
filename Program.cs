namespace Project;
public class Program {
    public static void Main(String[] args) {
        VaccineAnalisys analisys = new VaccineAnalisys();
        var covidCases = analisys.GetCovidCases();
        var endResult = analisys.CountCases(covidCases);
        Console.WriteLine(endResult.vaccinated + "/" + endResult.nonVaccinated);
    }
}