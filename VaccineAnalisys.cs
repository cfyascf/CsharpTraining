namespace Project;

public class VaccineAnalisys {
    string FilePath = "INFLUD21-01-05-2023.csv";
    int FinalDiagnosisColumn = 77;
    int IsVaccinatedColumn = 35;
    int HasDiedColumn = 79;

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
            if(columns[FinalDiagnosisColumn] == "5") {
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
            if(columns[HasDiedColumn] == "2") {
                if (columns[IsVaccinatedColumn] == "1") 
                    vaccinated++;
                else
                    nonVaccinated++;
            } 
        }

        return new Analisys(vaccinated, nonVaccinated);
    }
}