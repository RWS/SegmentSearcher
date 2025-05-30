﻿using Sdl.TellMe.ProviderApi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capybara.EditorPlugin.SegmentSearcher.TellMeProvider
{
    public class SegmentSeracherCommunitySupportAction : AbstractTellMeAction
    {
        public SegmentSeracherCommunitySupportAction()
        {
            Name = "RWS Community AppStore Forum";    
        }

        public override string Category => $"{PluginResources.Plugin_Name} results";

        public override Icon Icon => PluginResources.SegmentSearcher_Question;

        public override bool IsAvailable => true;

        public override void Execute()
        {
            Process.Start("https://community.rws.com/product-groups/trados-portfolio/rws-appstore/f/rws-appstore");
        }
    }
}
