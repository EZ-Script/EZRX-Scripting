# EZRX-Scripting

<img width="815" alt="image" src="https://github.com/EZ-Script/EZRX-Scripting/assets/1759994/062a3cd0-ca14-40ba-9502-911c6ef1e2b5">

# Overview

EZRX is a plug-in for Rhino that helps a user use Chat GPT to create scripted Grasshopper nodes. We built this for the AEC Tech 2023 Hackathon in New York hosted by CORE studio and Thornton Thomasetti.

<img width="789" alt="image" src="https://github.com/EZ-Script/EZRX-Scripting/assets/1759994/08191c6e-8b9b-463a-8190-72236105c94e">

# Background and Motivation

Architects don't have time or motivation to learn to code, but would benefit from using scripts for creating reproducible workflows and more complex forms. 

<img width="858" alt="image" src="https://github.com/EZ-Script/EZRX-Scripting/assets/1759994/85be4260-c55f-4816-ae4f-1ae264c18620">

Today an architect can use Chat GPT to request code, but someone without programming experience can find it hard to get Chat GPT to produce working code. 
They need to provide sufficient context with the prompt to get a working result. 

# What we did 

A lot of our time was spent as a group trying to understand narrow down our original mandate of "making coding easier". We wanted to understand what that 
meant exactly, how we might achieve that, which persona we wanted to focus on and what use case we were targetting. 

Once we arrived at the we designed and coded three primary components:

* A tool for generating grasshopper nodes that dynamically compile and execute arbitrary C# code read from a file
* An API for sending prompts to and reading responses of the Chat GPT API, with additional context provided to prompt to produce better code
* A UI to allow the user to provide a prompt and review the generated code, before generating a node from it

# Architecture Overview

<img width="827" alt="image" src="https://github.com/EZ-Script/EZRX-Scripting/assets/1759994/900ab1a6-3ab6-4904-9aee-156b32345a06">

# Libraries used

* Rhino API - For creating Grasshopper nodes 
* Roslyn SDK - C# Compiler
* [Ara3D Library](https://github.com/ara3d/ara3d) - utility library and convenience functions
* [OpenAI Unoffical .NET API](https://github.com/OkGoDoIt/OpenAI-API-dotnet) 

# What we learned 

* Don't post API keys to Github
* If you accidentally post your OpenAPI API key to Github, OpenAPI will revoke it very quickly!
* Don't ask too much from your prompt or it can get confused 
* Chat GPT 4 is much more powerful than GPT 3.5 and can handle more complex requests 
* Getting working code requires providing a lot of additional context  
* We found that the unofficial OpenAPI .NET worked better than the official one.
* How you phrase a prompt makes a big difference
* ChatGPT will not always produce the same results.
* Architects don't necessarily want to learn to code, they want to realize their designs quicker 
  
# Next Steps 

We only had 26 hours to write the code and submit the presentation so there is a lot left to do. 

## Technical Debt and Code Clean-up 
* Test the system on other person's machine 
* Refactor the code to make it easier to run and modify
* Create an installer
* Document the build process

## Features 

* Storing prompts and the results and making them searchable
* Supporting different output types other than just mesh 
* Allowing customized inputs
* Allow the prompt contexts to be updated by the user
* Allow the generated code to be used in other context
* Train models to create and recognize a generic structure for describing inputs/outputs 

# Cloning the Repository 

This module used the `github.com\ara3d\ara3d` project as a submodule.

From the command-line you can pull the submodules using:

```
git submodule update --init --recursive
```

# Building and Running the Code

We only had time to get the code running on one user's machine. 
We unfortunately do not have the steps documented to copy and run the files. 

# Who are We

We are the EZ Script team. 
* Christopher Diggins - Software Developer
* Emma Xu - Architecture Student
* Travis Potter - Software Engineer and MEP Engineer
* Haki Sallaku - Computer Science Student
* Sun Lee - Computational Designer and Architect
* Bell Wang - Architecture Student
* Marcelo Villalba - Software Engineer

![ezrx-img_3665](https://github.com/EZ-Script/EZRX-Scripting/assets/1759994/8a5a9ae2-b759-4b8d-a2f2-2dbbda13120b)

