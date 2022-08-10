namespace CarsUnlimited.Shared.Configuration
{
    public class TracingConfiguration
    {
        public int Exporter { get; set; }
        public string ZipkinEndpoint { get; set; }
        public JaegerConfiguraton JaegerEndpoint { get; set; }
        public string OltpEndpoint { get; set; }
    }

    public class JaegerConfiguraton
    {
        public string Host { get; set; }
        public int Port { get; set; }
    }

    public enum TraceExporterOptions
    {
        CONSOLE = -1,
        JAEGER = 0,
        ZIPKIN = 1,
        OPENTELEMETRY_PROTOCOL = 2
    }
}