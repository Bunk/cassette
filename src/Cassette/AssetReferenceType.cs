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

namespace Cassette
{
    public enum AssetReferenceType
    {
        /// <summary>
        /// A reference to an asset in the same module as the referencing asset.
        /// </summary>
        SameModule,
        /// <summary>
        /// A reference to an asset in another module, or to an entire other module itself.
        /// </summary>
        DifferentModule,
        /// <summary>
        /// For example, a reference to an image from a CSS file.
        /// </summary>
        RawFilename,
        /// <summary>
        /// A direct reference to a URL.
        /// </summary>
        Url
    }
}
