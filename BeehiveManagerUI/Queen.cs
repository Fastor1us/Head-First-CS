﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BeehiveManagerUI
{
    internal class Queen : Bee
    {
        public override float CostPerShift { get; } = 2.15F;
        private readonly List<Bee> workers = new List<Bee>();
        private float eggs = 0;
        public float UnassignedWorkers { get; private set; } = 4;
        const float EGGS_PER_SHIFT = 0.45F;
        const float HONEY_PER_UNASSIGNED_WORKER = 0.5F;

        public Queen() : base("Queen")
        {
            AssignBee("Nectar Collector");
            AssignBee("Honey Manufacturer");
            AssignBee("Egg Care");
        }

        protected override void DoJob()
        {
            eggs += EGGS_PER_SHIFT;
            foreach (var worker in workers)
            {   
                worker.WorkTheNextShift();
            }
            HoneyVault.ConsumeHoney(
                HONEY_PER_UNASSIGNED_WORKER * (int)UnassignedWorkers
            );
        }

        private void AddWorker(Bee bee)
        {
            if (UnassignedWorkers >= 1)
            {
                workers.Add(bee);
                UnassignedWorkers--;
            }
        }

        public void AssignBee(string job)
        {
            switch (job)
            {
                case "Nectar Collector":
                    AddWorker(new NectarCollector());
                    break;
                case "Honey Manufacturer":
                    AddWorker(new HoneyManufacturer());
                    break;
                case "Egg Care":
                    AddWorker(new EggCare(this));
                    break;
            }
        }

        public void CareForEggs(float eggsToConvert)
        {
            if (eggs >= eggsToConvert)
            {
                eggs -= eggsToConvert;
                UnassignedWorkers += eggsToConvert;
            }
        }

        public string StatusReport
        {
            get
            {
                string statusReport = String.Empty;
                statusReport += HoneyVault.StatusReport + "\n";
                statusReport += "Population:\n";
                statusReport += $"Egg count: {eggs:0.0}\n";
                statusReport += $"Unassigned workers: {UnassignedWorkers:0.0}\n";
                int nectarCollectorsCount = workers.Count(w => w is NectarCollector);
                int honeyManufacturersCount = workers.Count(w => w is HoneyManufacturer);
                int eggCarersCount = workers.Count(w => w is EggCare);
                statusReport += $"Nectar collector: {nectarCollectorsCount}\n";
                statusReport += $"Honey Manufacturer: {honeyManufacturersCount}\n";
                statusReport += $"Egg Carer: {eggCarersCount}\n";
                statusReport += $"TOTAL WORKERS: {workers.Count}\n";
                return statusReport;
            }
        }
    }
}
