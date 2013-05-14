﻿#region License
// CShell, A Simple C# Scripting IDE
// Copyright (C) 2012  Arnova Asset Management Ltd., Lukas Buhler
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
#endregion
using System;
using System.Windows.Forms;
using Caliburn.Micro;
using Microsoft.Win32;

namespace CShell.Framework.Results
{
	public class ShowFolderDialogResult : IResult
	{
	    public event EventHandler<ResultCompletionEventArgs> Completed;

	    public ShowFolderDialogResult()
	    { }

        public ShowFolderDialogResult(string selectedFolder)
        {
            this.SelectedFolder = selectedFolder;
        }

	    public string SelectedFolder { get; set; }

	    public void Execute(ActionExecutionContext context)
	    {
	        var dialog = new FolderBrowserDialog();
            if(!String.IsNullOrEmpty(SelectedFolder))
                dialog.SelectedPath = SelectedFolder;
	        var result = dialog.ShowDialog();
	        SelectedFolder = dialog.SelectedPath;
			Completed(this, new ResultCompletionEventArgs { WasCancelled = result != DialogResult.OK });
		}
	}
}