<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="SchooledAPICloud" generation="1" functional="0" release="0" Id="7cb07cdc-c6ed-4480-b8a9-ded62894d289" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="SchooledAPICloudGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="SchooledAPI:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/SchooledAPICloud/SchooledAPICloudGroup/LB:SchooledAPI:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="SchooledAPI:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/SchooledAPICloud/SchooledAPICloudGroup/MapSchooledAPI:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="SchooledAPIInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/SchooledAPICloud/SchooledAPICloudGroup/MapSchooledAPIInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:SchooledAPI:Endpoint1">
          <toPorts>
            <inPortMoniker name="/SchooledAPICloud/SchooledAPICloudGroup/SchooledAPI/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapSchooledAPI:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/SchooledAPICloud/SchooledAPICloudGroup/SchooledAPI/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapSchooledAPIInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/SchooledAPICloud/SchooledAPICloudGroup/SchooledAPIInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="SchooledAPI" generation="1" functional="0" release="0" software="C:\Users\Khan\Documents\SchooledAPI\SchooledAPI\SchooledAPICloud\csx\Release\roles\SchooledAPI" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="-1" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;SchooledAPI&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;SchooledAPI&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/SchooledAPICloud/SchooledAPICloudGroup/SchooledAPIInstances" />
            <sCSPolicyUpdateDomainMoniker name="/SchooledAPICloud/SchooledAPICloudGroup/SchooledAPIUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/SchooledAPICloud/SchooledAPICloudGroup/SchooledAPIFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="SchooledAPIUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="SchooledAPIFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="SchooledAPIInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="84335441-20c0-46c4-bd96-e8fd18d21262" ref="Microsoft.RedDog.Contract\ServiceContract\SchooledAPICloudContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="cab09a21-d240-4f54-b971-9dc5f3e5f272" ref="Microsoft.RedDog.Contract\Interface\SchooledAPI:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/SchooledAPICloud/SchooledAPICloudGroup/SchooledAPI:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>