rem %1 major, %2 minor, %3 patch
C:
cd C:\src\Bam.Net\BuildScripts\Bam.Net
call clean.cmd
call set_assembly_version.cmd %1 %2 %3
call set_nuspec_info.cmd %1 %2 %3
call generate_nuget_scripts.cmd
call build_solution.cmd Debug c:\src
call pack_debug.cmd

echo "Debug Nuget packages created"