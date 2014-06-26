﻿using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Debugger.Interop;
using Mono.Debugger.Soft;
using MonoDebugger.VS2013.Debugger.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace MonoDebugger.VS2013.Debugger
{
    public class MonoProgramNode : IDebugProgramNode2
    {
        private Guid _processId;
        private DebuggedMonoProcess _process;

        public MonoProgramNode(DebuggedMonoProcess process, Guid processId)
        {
            _process = process;
            _processId = processId;
        }

        public int Attach_V7(IDebugProgram2 pMDMProgram, IDebugEventCallback2 pCallback, uint dwReason)
        {
            DebugHelper.TraceEnteringMethod();
            return VSConstants.E_NOTIMPL;
        }

        public int DetachDebugger_V7()
        {
            DebugHelper.TraceEnteringMethod();
            return VSConstants.E_NOTIMPL;
        }

        public int GetHostMachineName_V7(out string pbstrHostMachineName)
        {
            DebugHelper.TraceEnteringMethod();
            pbstrHostMachineName = null;
            return VSConstants.E_NOTIMPL;
        }

        public int GetEngineInfo(out string pbstrEngine, out Guid pguidEngine)
        {
            DebugHelper.TraceEnteringMethod();
            pbstrEngine = MonoGuids.EngineName;
            pguidEngine = MonoGuids.EngineGuid;
            return VSConstants.S_OK;
        }

        public int GetHostName(enum_GETHOSTNAME_TYPE dwHostNameType, out string pbstrHostName)
        {
            DebugHelper.TraceEnteringMethod();
            pbstrHostName = null;
            _process.StartDebugging();
            return VSConstants.S_OK;
        }

        public int GetHostPid(AD_PROCESS_ID[] pHostProcessId)
        {
            DebugHelper.TraceEnteringMethod();
            pHostProcessId[0].ProcessIdType = (uint)enum_AD_PROCESS_ID.AD_PROCESS_ID_GUID;
            pHostProcessId[0].guidProcessId = _processId;
            return VSConstants.S_OK;
        }

        public int GetProgramName(out string pbstrProgramName)
        {
            DebugHelper.TraceEnteringMethod();
            pbstrProgramName = null;
            return VSConstants.E_NOTIMPL;
        }
    }
}