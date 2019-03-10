using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoverfly.Core.Configuration;
using System.IO;

namespace Magnalane.CompareComplyV1.IT
{
    public static class HoverFlyTestConfig1
    {
        public static string PackagePath => Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\packages\\SpectoLabs.Hoverfly.0.15.0\\tools\\");

        public static HoverflyConfig GetHoverFlyConfigWIthBasePath()
        {
            return HoverflyConfig.Config().SetHoverflyBasePath(PackagePath);
        }
    }
}
