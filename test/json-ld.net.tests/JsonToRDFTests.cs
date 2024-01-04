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
        var json = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Json", "ed25519signature2020-cred-without-proof.json"));
        var document = JObject.Parse(json);
        var rdf = (RDFDataset)JsonLdProcessor.ToRDF(document);
        var serialized = RDFDatasetUtils.ToNQuads(rdf);
        Assert.NotEmpty(serialized);
    }
}
