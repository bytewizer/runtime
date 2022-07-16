# Runtime libraries for TinyCLR and nanoFramework

[![NuGet Status](http://img.shields.io/nuget/v/Bytewizer.TinyCLR.Core.svg?style=flat&logo=nuget)](https://www.nuget.org/packages?q=bytewizer)
[![Release](https://github.com/bytewizer/runtime/actions/workflows/release.yml/badge.svg)](https://github.com/bytewizer/runtime/actions/workflows/release.yml)
[![Build](https://github.com/bytewizer/runtime/actions/workflows/actions.yml/badge.svg)](https://github.com/bytewizer/runtime/actions/workflows/actions.yml)

This repo contains several runtime libraries built for [GHI Electronics TinyCLR OS](https://www.ghielectronics.com/) and [.NET nanoFramework](https://www.nanoFramework.net). These libraries provide implementations for many general and app-specific types, algorithms, and utility functionality.

## TinyCLR OS and .NET nanoFramework

* [Runtime Core](https://github.com/bytewizer/runtime/tree/develop/src/core)
* [Time Measurement](https://github.com/bytewizer/runtime/tree/develop/src/stopwatch)
* [Testing Framework](https://github.com/bytewizer/runtime/tree/develop/src/assertions) 
* [Logging Framework](https://github.com/bytewizer/runtime/tree/develop/src/logging) 
* [Middleware Pipeline](https://github.com/bytewizer/runtime/tree/develop/src/pipeline)
* [Generic Host (Hosting)](https://github.com/bytewizer/runtime/tree/develop/src/hosting) 
* [Dependency Injection (DI)](https://github.com/bytewizer/runtime/tree/develop/src/di)
* [Deflate, Zip, Gzip Compression](https://github.com/bytewizer/runtime/tree/develop/src/compression)  
* [Identity Management - TinyCLR Only**](https://github.com/bytewizer/runtime/tree/develop/src/identity)

**Note: Incompatible api footprints are bing researched between the two platforms. Other libraries will be updated as incompatibilities are worked around.  

## Networking libraries
This [repo](https://github.com/bytewizer/microserver) contains several runtime libraries. These libraries provide implementations for networking, web and socket services.

## Give a Star! :star:

If you like or are using this project to start your solution, please give it a star. Thanks!

## Requirements

Software: <a href="https://visualstudio.microsoft.com/downloads/">Visual Studio 2019/2022</a> and <a href="https://www.ghielectronics.com/">GHI Electronics TinyCLR OS</a> or <a href="https://www.nanoFramework.net/">.NET nanoFramework OS</a>.  

## Nuget Packages

Install releases package from [NuGet](https://www.nuget.org/packages?q=bytewizer). Development build packages are available as [Github Packages](https://github.com/bytewizer?tab=packages).

## Continuous Integration

**main** :: This is the branch containing the latest release build. No contributions should be made directly to this branch. The development branch will periodically be merged to the main branch, and be released to [NuGet](https://www.nuget.org/packages?q=bytewizer).

**develop** :: This is the development branch to which contributions should be proposed by contributors as pull requests. Development build packages are available as [Github Packages](https://github.com/bytewizer?tab=packages).

## Contributions

Contributions to this project are always welcome. Please consider forking this project on GitHub and sending a pull request to get your improvements added to the original project.

## Disclaimer

All source, documentation, instructions and products of this project are provided as-is without warranty. No liability is accepted for any damages, data loss or costs incurred by its use.