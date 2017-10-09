# SystemWeaver-Jira integration sample

This demo shows how to integrate SystemWeaver with Jira by building an to the swExplorer which shows Jira issues connected to a given item.

The SystemWeaver item and the Jira issue are connected by a custom field of type text which are supposed to contain a SystemWeaver url


## Prerequisites

- You need a SystemWeaver the swExplorer.exe and the files in the swExplorerExtensions folder.
- You need RemObjects Hydra which is the technology used in swExplorer to build extensions. 
- You need a Jira server to test against

## Building

From the SystemWeaver Client application, put the swExplorer.exe into the Imported directory, and put SystemWeaverExtensionsAPI.dll, RemObjects.Hydra.dll and RemObjects.Hydra.WPF.dll into the Imported/swExplorerExtensions directory.

Then you just build the application extension.

The csproj file contains a reference to swExplorer.exe as start program for the dll you are building enabling you to just run and test the extensions.

## Documentation

For more information, please consult our customer portal on https://support.systemweaver.se/solution/articles/31000134989-systemweaver-jira-integration.



