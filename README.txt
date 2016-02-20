Installing the Custom Task
----------------------------------------
The custom task is in this assembly (DLL): SasSpawnedProcesses.dll.  
It can work with SAS Enterprise Guide 4.3 and later, connected to SAS 9.3 and later.

To install the custom task for use with SAS Enterprise Guide 4.3 or later, 
you simply need to copy the DLL to a designated directory (slightly different
for each version of SAS Enterprise Guide):

- For use by just the current user, copy the DLL to: 
     %appdata%\SAS\EnterpriseGuide\4.3\Custom 
	 %appdata%\SAS\EnterpriseGuide\5.1\Custom 
	 %appdata%\SAS\EnterpriseGuide\6.1\Custom 
	 %appdata%\SAS\EnterpriseGuide\7.1\Custom 

  where %appdata% is a Windows environment variable that resolves to your profile area. 
  You might need to create the “Custom” subfolder in this area.

- For use by all users on a machine, copy the DLL to: 
  %programfiles%\SAS\EnterpriseGuide\4.3\Custom 
  %programfiles%\SAS\EnterpriseGuide\5.1\Custom 
  %programfiles%\SAS\EnterpriseGuide\6.1\Custom 
  %programfiles%\SAS\EnterpriseGuide\7.1\Custom 

  You might need to create the “Custom” subfolder in this area. 
  You might need elevated privileges on your machine to copy content into the Program Files area.

If you downloaded the task from the SAS website, you might also need to Unblock the 
DLL on your system to allow SAS Enterprise Guide to access it.  Microsoft Windows
has a security feature that prevents downloaded DLL files from working until you unblock them.
See instructions here:
  http://blogs.sas.com/content/sasdummy/unblocking-custom-task-dlls/

After the file is copied into place, restart SAS Enterprise Guide. 
The tasks should be available from the Tools->Add-In menu.