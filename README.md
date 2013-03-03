NCLDR
=====

NCLDR is an open source .NET port of [CLDR](http://cldr.unicode.org/) (the Common Locale Data Repository).

CLDR serves the same purpose as the .NET Framework's System.Globalization namespace and the culture data made available through the CultureInfo and RegionInfo classes. The difference, however, is that CLDR contains almost twice the number of cultures and includes additional data for each culture that is not included in the .NET Framework. NCLDR brings these cultures and this additional data to .NET developers.

##Status

NCLDR is currently an alpha release. It exists as a preview that lets you view the potential of a complete product.

What is complete:-
* Most of the CLDR data is exposed through NCLDR
* Support for creating .NET custom cultures from CLDR data is mostly complete
* Many extension methods exist to expose CLDR data through .NET CultureInfo and RegionInfo classes
* The NCLDRExplorer to view NCLDR data is mostly complete

What is still to do:-
* In general the main part of NCLDR that is currently missing is a layer of intelligence on top of the data that makes the data valuable.
* Documentation. At present the source code includes XML code comments but there is no documentation beyond this.

##NCLDR Videos

The simplest way to get up and running with NCLDR is to watch a series of short videos on the [NCLDR website](http://www.ncldr.com):-

* What is NCLDR ?
* Getting Started With NCLDR
* Creating Custom Cultures With NCLDR
* Using NCLDR Extension Methods
* Customizing The NCLDR Data File
* Exploring NCLDR Data
* Using NCLDR Cultures In JavaScript

##Getting Started

1. Download the NCLDR [source code](http://www.github.com/GuySmithFerrier/NCLDR).
2. Open Visual Studio 2012 or later and build the NCLDR.sln solution.
3. Download CLDR release 22.1 or later from [http://cldr.unicode.org/index/downloads](http://cldr.unicode.org/index/downloads).
4. Run NCldrBuilderCmd.exe to build the NCLDR.dat data file from the CLDR XML files (you only need to do this once).
5. Run NCldrExplorer.exe to view the NCLDR data and/or to create NCLDR custom cultures.
6. Either: Add references to NCldr.dll and NCldrExtensions.dll to your application to use NCLDR data in your applications.
7. Or: Add the NCLDR (Pre-Release) NuGet package to your application.

##License

MIT license - [http://www.opensource.org/licenses/mit-license.php](http://www.opensource.org/licenses/mit-license.php)
