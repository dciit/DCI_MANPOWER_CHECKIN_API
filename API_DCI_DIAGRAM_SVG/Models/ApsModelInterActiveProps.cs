namespace API_DCI_DIAGRAM_SVG.Models
{
    public class ApsModelInterActiveProps
    {
        public string time { get; set; }
        public string modelCode { get; set; }
        public string modelName { get; set; }
        public int result { get; set; }
        public statorProps stator { get; set; } = new statorProps();
        public rotorProps rotor { get; set; } = new rotorProps();
        public housingProps housing { get; set; } = new housingProps();
        public crankShaftProps crankShaft { get; set; } = new crankShaftProps();
        public fsOsProps fsOs { get; set; } = new fsOsProps();
        public lowerProps lower { get; set; } = new lowerProps();
        public pipeProps pipe { get; set; } = new pipeProps();
        public topProps top { get; set; } = new topProps();
        public bottomProps bottom { get; set; } = new bottomProps();
    }
    public class wipProps
    {
        public string name { get; set; }
        public int cnt { get; set; } = 0;
    }
    public class bottomProps
    {
        public int main { get; set; } = 0;
        public int casing { get; set; } = 0;
    }
    public class topProps {
        public int main { get; set; } = 0;
        public int casing { get; set; } = 0;
    }
    public class pipeProps
    {
        public int main { get; set; } = 0;
        public int casing { get; set; } = 0;
    }
    public class lowerProps
    {
        public int main { get; set; } = 0;
        public int mc { get; set; } = 0;
    }
    public class statorProps
    {

        public double main { get; set; } = 0;
        public int motor { get; set; } = 0;
    }
    public class rotorProps
    {
        public int main { get; set; } = 0;
        public int motor { get; set; } = 0;
    }

    public class housingProps
    {
        public int main { get; set; } = 0;
        public int mc { get; set; } = 0;
    }
    public class crankShaftProps
    {
        public int main { get; set; } = 0;
        public int mc { get; set; } = 0;
    }
    public class fsOsProps
    {
        public int main { get; set; } = 0;
        public int mc { get; set; } = 0;
    }
}
