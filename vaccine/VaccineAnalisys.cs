namespace Project;

public class VaccineAnalisys {
    int FinalDiagnosisColumn = 106;
    int IsVaccinatedColumn = 154;
    int HasDiedColumn = 109;

    public IEnumerable<string> ReadLine() {
        using var reader = new StreamReader("INFLUD21-01-05-2023.csv");

        string line = "";
        while(line is not null) {
            line = reader.ReadLine();
            yield return line;
        }
    }

    public List<string> GetCovidCases() {
        List<string> covidCases = new List<string>();

        foreach(var line in ReadLine()) {
            if(line == null) continue;

            var columns = line.Split(';');
            if(columns[FinalDiagnosisColumn].Contains('5')) {
                covidCases.Add(line);
            }
        }

        return covidCases;
    }

    public Analisys CountCases(List<string> covidCases) {
        int vaccinated = 0;
        int nonVaccinated = 0;

        foreach (var item in covidCases)
        {
            var columns = item.Split(';');
            if(columns[HasDiedColumn].Contains('2')) {
                if (columns[IsVaccinatedColumn].Contains('1')) 
                    vaccinated++;
                else
                    nonVaccinated++;
            } 
        }

        return new Analisys(vaccinated, nonVaccinated);
    }
}