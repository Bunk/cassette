﻿#region License
/*
Copyright 2011 Andrew Davey

This file is part of Cassette.

Cassette is free software: you can redistribute it and/or modify it under the 
terms of the GNU General Public License as published by the Free Software 
Foundation, either version 3 of the License, or (at your option) any later 
version.

Cassette is distributed in the hope that it will be useful, but WITHOUT ANY 
WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS 
FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with 
Cassette. If not, see http://www.gnu.org/licenses/.
*/
#endregion

using System.Collections.Generic;
using Cassette.ModuleProcessing;

namespace Cassette.Stylesheets
{
    public class StylesheetPipeline : MutablePipeline<StylesheetModule>
    {
        public StylesheetPipeline()
        {
            StylesheetMinifier = new MicrosoftStyleSheetMinifier();
            CompileLess = true;
        }

        public IAssetTransformer StylesheetMinifier { get; set; }
        public bool CompileLess { get; set; }
        public bool ConvertImageUrlsToDataUris { get; set; }

        protected override IEnumerable<IModuleProcessor<StylesheetModule>> CreatePipeline(StylesheetModule module, ICassetteApplication application)
        {
            yield return new ParseCssReferences();
            if (CompileLess)
            {
                yield return new ParseLessReferences();
                yield return new CompileLess(new LessCompiler());
            }
            yield return new ExpandCssUrls();
            if (ConvertImageUrlsToDataUris)
            {
                yield return new AddTransformerToAssets(new DataUriGenerator());
            }
            yield return new SortAssetsByDependency();
            if (application.IsOutputOptimized)
            {
                yield return new ConcatenateAssets();
                yield return new MinifyAssets(StylesheetMinifier);
            }
            yield return new AssignRenderer();
        }
    }
}
