using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace proxyform
{
    public class PerfTools
    {
        PerformanceCounter cpuCounter;
        PerformanceCounter ramCounter;

        public PerfTools()
        {
            cpuCounter = new PerformanceCounter();

            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";

            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        }

        public string getCurrentCpuUsage(){
            return Convert.ToString(cpuCounter.NextValue());
        }

        internal string getAvailableRAM(){
                    return ramCounter.NextValue()+"MB";
        } 
    }
}
