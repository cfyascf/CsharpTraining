namespace Project;
public class Program {
    public static void Main(String[] args) {
        VaccineAnalisys analisys = new VaccineAnalisys();
        var covidCases = analisys.GetCovidCases();
        var endResult = analisys.CountCases(covidCases);
        Console.WriteLine("Died vaccinated:" + endResult.vaccinated + "/" + "Died non vaccinated:" + endResult.nonVaccinated);
    }
}