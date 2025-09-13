namespace Circuits
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAnd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOr = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonNot = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonInputSource = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOutputLamp = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEvaluation = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStartGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEndGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAnd,
            this.toolStripButtonOr,
            this.toolStripButtonNot,
            this.toolStripButtonInputSource,
            this.toolStripButtonOutputLamp,
            this.toolStripButtonEvaluation,
            this.toolStripButtonCopy,
            this.toolStripButtonStartGroup,
            this.toolStripButtonEndGroup});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.toolStrip1.Size = new System.Drawing.Size(2016, 50);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAnd
            // 
            this.toolStripButtonAnd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAnd.Image = global::Circuits.Properties.Resources.AndIcon;
            this.toolStripButtonAnd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAnd.Name = "toolStripButtonAnd";
            this.toolStripButtonAnd.Size = new System.Drawing.Size(46, 44);
            this.toolStripButtonAnd.Text = "And Gate";
            this.toolStripButtonAnd.Click += new System.EventHandler(this.toolStripButtonAnd_Click);
            // 
            // toolStripButtonOr
            // 
            this.toolStripButtonOr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOr.Image = global::Circuits.Properties.Resources.OrIcon;
            this.toolStripButtonOr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOr.Name = "toolStripButtonOr";
            this.toolStripButtonOr.Size = new System.Drawing.Size(46, 44);
            this.toolStripButtonOr.Text = "Or Gate";
            this.toolStripButtonOr.Click += new System.EventHandler(this.toolStripButtonOr_Click);
            // 
            // toolStripButtonNot
            // 
            this.toolStripButtonNot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNot.Image = global::Circuits.Properties.Resources.NotIcon;
            this.toolStripButtonNot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNot.Name = "toolStripButtonNot";
            this.toolStripButtonNot.Size = new System.Drawing.Size(46, 44);
            this.toolStripButtonNot.Text = "Not Gate";
            this.toolStripButtonNot.Click += new System.EventHandler(this.toolStripButtonNot_Click);
            // 
            // toolStripButtonInputSource
            // 
            this.toolStripButtonInputSource.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonInputSource.Image = global::Circuits.Properties.Resources.InputIcon;
            this.toolStripButtonInputSource.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonInputSource.Name = "toolStripButtonInputSource";
            this.toolStripButtonInputSource.Size = new System.Drawing.Size(46, 44);
            this.toolStripButtonInputSource.Text = "Input Source";
            this.toolStripButtonInputSource.Click += new System.EventHandler(this.toolStripButtonInputSource_Click);
            // 
            // toolStripButtonOutputLamp
            // 
            this.toolStripButtonOutputLamp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOutputLamp.Image = global::Circuits.Properties.Resources.OutputOff;
            this.toolStripButtonOutputLamp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOutputLamp.Name = "toolStripButtonOutputLamp";
            this.toolStripButtonOutputLamp.Size = new System.Drawing.Size(46, 44);
            this.toolStripButtonOutputLamp.Text = "Output Lamp";
            this.toolStripButtonOutputLamp.Click += new System.EventHandler(this.toolStripButtonOutputLamp_Click);
            // 
            // toolStripButtonEvaluation
            // 
            this.toolStripButtonEvaluation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEvaluation.Image = global::Circuits.Properties.Resources.EvaluateIcon;
            this.toolStripButtonEvaluation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEvaluation.Name = "toolStripButtonEvaluation";
            this.toolStripButtonEvaluation.Size = new System.Drawing.Size(46, 44);
            this.toolStripButtonEvaluation.Text = "Evaluation";
            this.toolStripButtonEvaluation.Click += new System.EventHandler(this.toolStripButtonEvaluation_Click);
            // 
            // toolStripButtonCopy
            // 
            this.toolStripButtonCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCopy.Image = global::Circuits.Properties.Resources.CopyIcon;
            this.toolStripButtonCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCopy.Name = "toolStripButtonCopy";
            this.toolStripButtonCopy.Size = new System.Drawing.Size(46, 44);
            this.toolStripButtonCopy.Text = "Copy";
            this.toolStripButtonCopy.Click += new System.EventHandler(this.toolStripButtonCopy_Click);
            // 
            // toolStripButtonStartGroup
            // 
            this.toolStripButtonStartGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStartGroup.Image = global::Circuits.Properties.Resources.StartCompoundIcon;
            this.toolStripButtonStartGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStartGroup.Name = "toolStripButtonStartGroup";
            this.toolStripButtonStartGroup.Size = new System.Drawing.Size(46, 44);
            this.toolStripButtonStartGroup.Text = "Start Group";
            this.toolStripButtonStartGroup.Click += new System.EventHandler(this.toolStripButtonStartGroup_Click);
            // 
            // toolStripButtonEndGroup
            // 
            this.toolStripButtonEndGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEndGroup.Image = global::Circuits.Properties.Resources.EndCompoundIcon;
            this.toolStripButtonEndGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEndGroup.Name = "toolStripButtonEndGroup";
            this.toolStripButtonEndGroup.Size = new System.Drawing.Size(46, 44);
            this.toolStripButtonEndGroup.Text = "End Group";
            this.toolStripButtonEndGroup.Click += new System.EventHandler(this.toolStripButtonEndGroup_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(2016, 1402);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Circuits 2023";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAnd;
        private System.Windows.Forms.ToolStripButton toolStripButtonOr;
        private System.Windows.Forms.ToolStripButton toolStripButtonNot;
        private System.Windows.Forms.ToolStripButton toolStripButtonInputSource;
        private System.Windows.Forms.ToolStripButton toolStripButtonOutputLamp;
        private System.Windows.Forms.ToolStripButton toolStripButtonEvaluation;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopy;
        private System.Windows.Forms.ToolStripButton toolStripButtonStartGroup;
        private System.Windows.Forms.ToolStripButton toolStripButtonEndGroup;
    }
}

