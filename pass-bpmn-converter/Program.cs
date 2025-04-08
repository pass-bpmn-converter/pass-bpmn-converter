using alps.net.api.StandardPASS;
using PassBpmnConverter.Bpmn;
using PassBpmnConverter.Conversion;
using PassBpmnConverter.Pass;

namespace PassBpmnConverter;

public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine($"No input and/or output file path provided. Usage: pass-bpmn-converter.exe <owl_input_file_path> <bpmn_output_file_path>.");
            return;
        }

        string inputFilePath = args[0];
        string outputFilePath = args[1];

        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine($"Error: Input file {inputFilePath} does not exist.");
            return;
        }

        IList<IPASSProcessModel> passModels = PassParser.LoadModels(new List<string>() { inputFilePath });

        if (passModels.Count < 1)
            return;

        IPASSProcessModel? passModel = passModels.FirstOrDefault();

        if (passModel == null)
            return;

        IBpmnModel bpmnModel = Converter.ConvertPassToBpmn(passModel);

        BpmnDiagramGenerator.GenerateDiagram(bpmnModel);

        BpmnSerializer.Serialize(bpmnModel, outputFilePath);
    }
}