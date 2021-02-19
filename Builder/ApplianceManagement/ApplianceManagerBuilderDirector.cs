using Builder.ApplianceManagement.ApplianceBuilder;


namespace Builder.ApplianceManagement
{
    public class ApplianceManagerBuilderDirector
    {
        private IApplianceManagerBuilder _builder;

        public ApplianceManagerBuilderDirector(IApplianceManagerBuilder builder)
        {
            _builder = builder;
        }
        public void BuildApplianceManager()
        {
            _builder.AddApplianceManagerIdentifiers("HeatPump00657", "OvumHeatPump056")
                    .AddIPConfiguration("192.168.45.01", 502)
                    .AddAppServerConfiguration(3000, 2);
        }
    }
}
