using alps.net.api.parsing;
using alps.net.api.StandardPASS;

namespace PassBpmnConverter.Pass;

public static class PassParser
{
    // TODO: change to load a single model instead
    public static IList<IPASSProcessModel> LoadModels(IList<string> filepaths)
    {
        IPASSReaderWriter io = PASSReaderWriter.getInstance();

        io.loadOWLParsingStructure(
            new List<string>
            {
                "resources/standard_PASS_ont_v_1.1.0.owl",
                "resources/ALPS_ont_v_0.8.0.owl",
            }
        );

        IList<IPASSProcessModel> models = io.loadModels(filepaths);

        return models;
    }
}
