﻿namespace ReportConfigurationMS.Domain;

public class CustomFile
{
    public byte[] Bytes { get; set; }
    public string ContentType { get; set; }
    public string FileName { get; set; }
}