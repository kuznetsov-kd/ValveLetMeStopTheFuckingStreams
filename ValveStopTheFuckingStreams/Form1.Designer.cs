namespace ValveStopTheFuckingStreams;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        StopButton = new System.Windows.Forms.Button();
        clearButton = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        blockedDomainsCount = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // StopButton
        // 
        StopButton.Location = new System.Drawing.Point(12, 12);
        StopButton.Name = "StopButton";
        StopButton.Size = new System.Drawing.Size(416, 105);
        StopButton.TabIndex = 0;
        StopButton.Text = "Stop It";
        StopButton.UseVisualStyleBackColor = true;
        StopButton.Click += StopButton_Click;
        // 
        // clearButton
        // 
        clearButton.Location = new System.Drawing.Point(12, 165);
        clearButton.Name = "clearButton";
        clearButton.Size = new System.Drawing.Size(416, 47);
        clearButton.TabIndex = 1;
        clearButton.Text = "Clear";
        clearButton.UseVisualStyleBackColor = true;
        clearButton.Click += clear_Click;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(12, 120);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(272, 42);
        label1.TabIndex = 3;
        label1.Text = "Blocked domains count:";
        // 
        // blockedDomainsCount
        // 
        blockedDomainsCount.Location = new System.Drawing.Point(290, 120);
        blockedDomainsCount.Name = "blockedDomainsCount";
        blockedDomainsCount.Size = new System.Drawing.Size(138, 42);
        blockedDomainsCount.TabIndex = 4;
        blockedDomainsCount.Text = "0";
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(436, 228);
        Controls.Add(blockedDomainsCount);
        Controls.Add(label1);
        Controls.Add(clearButton);
        Controls.Add(StopButton);
        MaximumSize = new System.Drawing.Size(462, 299);
        MinimumSize = new System.Drawing.Size(462, 299);
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "VSTFS";
        Load += Form1_Load;
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label blockedDomainsCount;

    private System.Windows.Forms.Button clearButton;
    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Button StopButton;

    #endregion
}