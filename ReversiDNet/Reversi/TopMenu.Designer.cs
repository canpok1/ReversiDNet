namespace Reversi
{
	partial class TopMenu
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.p1_vs_lv1 = new System.Windows.Forms.Button();
			this.lv1_vs_p1 = new System.Windows.Forms.Button();
			this.END = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// p1_vs_lv1
			// 
			this.p1_vs_lv1.Location = new System.Drawing.Point( 12, 136 );
			this.p1_vs_lv1.Name = "p1_vs_lv1";
			this.p1_vs_lv1.Size = new System.Drawing.Size( 120, 23 );
			this.p1_vs_lv1.TabIndex = 0;
			this.p1_vs_lv1.Text = "P1 VS CP(LV1)";
			this.p1_vs_lv1.UseVisualStyleBackColor = true;
			this.p1_vs_lv1.Click += new System.EventHandler( this.p1_vs_lv1_Click );
			// 
			// lv1_vs_p1
			// 
			this.lv1_vs_p1.Location = new System.Drawing.Point( 152, 136 );
			this.lv1_vs_p1.Name = "lv1_vs_p1";
			this.lv1_vs_p1.Size = new System.Drawing.Size( 120, 23 );
			this.lv1_vs_p1.TabIndex = 1;
			this.lv1_vs_p1.Text = "CP(LV1) VS P1";
			this.lv1_vs_p1.UseVisualStyleBackColor = true;
			this.lv1_vs_p1.Click += new System.EventHandler( this.lv1_vs_p1_Click );
			// 
			// END
			// 
			this.END.Location = new System.Drawing.Point( 197, 227 );
			this.END.Name = "END";
			this.END.Size = new System.Drawing.Size( 75, 23 );
			this.END.TabIndex = 2;
			this.END.Text = "END";
			this.END.UseVisualStyleBackColor = true;
			this.END.Click += new System.EventHandler( this.END_Click );
			// 
			// TopMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 284, 262 );
			this.Controls.Add( this.END );
			this.Controls.Add( this.lv1_vs_p1 );
			this.Controls.Add( this.p1_vs_lv1 );
			this.Name = "TopMenu";
			this.Text = "TopMenu";
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.Button p1_vs_lv1;
		private System.Windows.Forms.Button lv1_vs_p1;
		private System.Windows.Forms.Button END;
	}
}