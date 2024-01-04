using JsonLD.Core;
using Newtonsoft.Json.Linq;
using System.IO;
using Xunit;

namespace JsonLD.Test;

public class JsonToRDFTests
{
    [Fact]
    public void TransformJsonToRDF()
    {
        var json = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Json", "credential.json"));
        var document = JObject.Parse(json);
        var rdf = (RDFDataset)JsonLdProcessor.ToRDF(document);
        var serialized = RDFDatasetUtils.ToNQuads(rdf);
        Assert.NotEmpty(serialized);
    }
}
