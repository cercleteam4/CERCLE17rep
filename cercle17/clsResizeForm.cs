using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cercle17
{
    public class clsResizeForm
    {
        //Single RatioAlto;
        //Single RatioAncho;

        //public void   ResizeForm(Form ObjForm,int DesignerAncho,int DesignerAlto)
        //{
        //    int i_StandardHeight=DesignerAlto;
        //    int i_StandardWidth=DesignerAncho;
        //    int i_PresentHeight=Screen.PrimaryScreen.Bounds.Height;
        //    int i_PresentWidth=Screen.PrimaryScreen.Bounds.Width;

        //    RatioAlto  = (i_PresentHeight) / (i_StandardHeight);
        //    RatioAncho  = (i_PresentWidth) / (i_StandardWidth);
        //    ObjForm.AutoScaleMode=AutoScaleMode.None;
        //    ObjForm.Scale( SizeF(RatioAncho,RatioAlto));
        //    foreach (Control control in ObjForm.Controls )
        //    {
        //        if (control.HasChildren)
        //        {
        //            ResizeControlStore(control);
        //        }
        //        else
        //        {
        //            control.Font= ObjForm.Controls.Font(ObjForm.Font.FontFamily, ObjForm.Font.Size * RatioAlto , ObjForm.Font.Style, ObjForm.Font.Unit,Convert.ToByte(0));
        //            //control.Font=
        //        } //if (control.HasChildren)

        //    } //foreach (Control control in this.Controls)

        //} //public ResizeForm(Form ObjForm,int DesignerAncho,int DesignerAlto)

        //private void ResizeControlStore(Control objCtl)
        //{
        //    if (objCtl.HasChildren )
        //    {
        //        foreach (Control cChildren in this.Controls)
        //        {
        //            if (cChildren.HasChildren)
        //            {
        //                ResizeControlStore(cChildren);
        //            }
        //            else
        //            {
        //                cChildren.Font=Font(cChildren.Font.FontFamily,cChildren.Font.Size *RatioAlto ,cChildren.Font.Style ,cChildren.Font.Unit,Convert.ToByte(0));
        //            }
        //        }
        //    }
        //    else
        //    {
        //        objCtl.Font= Font(objCtl.Font.FontFamily, objCtl.Font.Size * RatioAlto , objCtl.Font.Style, objCtl.Font.Unit, Convert.ToByte(0));
        //    }   //if (objCtl.HasChildren )
        //}   //private ResizeControlStore(Control objCtl)
    } //public class clsResizeForm

} //namespace cercle17
