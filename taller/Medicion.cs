class Medicion
{
    public string Structure { get; set; }
    public string Operation { get; set; }
    public int N { get; set; }
    public int Repetition { get; set; }
    public long ElapsedTicks { get; set; }
    public double MicrosecondsPerOp { get; set; }
    public long Checksum { get; set; }

    public Medicion(string structure, string operation, int n, int repetition,
                     long elapsedTicks, double microsecondsPerOp, long checksum)
    {
        Structure = structure;
        Operation = operation;
        N = n;
        Repetition = repetition;
        ElapsedTicks = elapsedTicks;
        MicrosecondsPerOp = microsecondsPerOp;
        Checksum = checksum;
    }
}