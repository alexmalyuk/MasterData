using MD.Data.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace MasterData.Models
{
    public class ContractorInfo
    {
        public String NodeAlias { get; set; }

        public String NativeId { get; set; }

        public string Name { get; set; }

        public string FullName { get; set; }

        public string INN { get; set; }

        public string OKPO { get; set; }

        public string VATCertificateNumber { get; set; }

        public string LegalAddress { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public void Save()
        {
            
            // примерный алгоритм при сохранении контрагента
            //
            //- найти контрагента по ИНН
            //- если не нашли - создать
            //- дописать запись в Link

            using(MdContext db = new MdContext())
            {
                Node node = Node.FindByAlias(this.NodeAlias, db);
                if (node == null)
                    return ;

                // check the Contractor
                Contractor contractor = Contractor.FindByINN(this.INN);
                if (contractor == null)
                {
                    contractor = new Contractor();
                    db.Contractors.Add(contractor);
                }
                else
                {
                    //db.Entry(contractor).State = EntityState.Modified;
                    db.Contractors.Attach(contractor);
                }
                contractor.FullName = this.FullName;
                contractor.INN = this.INN;
                contractor.LegalAddress = this.LegalAddress;
                contractor.Name = this.Name;
                contractor.OKPO = this.OKPO;
                contractor.VATCertificateNumber = this.VATCertificateNumber;

                db.SaveChanges();

                // check the Link
                if (!Link.Exists(node.Id, this.NativeId))
                {
                    Link link = new Link();
                    link.NodeId = node.Id;
                    link.NativeId = this.NativeId;
                    link.ContractorId = contractor.Id;
                    link.Date = DateTime.Now;
                    db.Links.Add(link);
                }

                db.SaveChanges();
            }
        }

        public static ContractorInfo GetByNativeId(string NativeId, string NodeAlias)
        {
            MdContext db = new MdContext();

            Node node = Node.FindByAlias(NodeAlias);
            if (node == null)
                return null;

            var q = db.Links.Where(a => a.NativeId == NativeId && a.NodeId == node.Id).Join(
                db.Contractors,
                l => l.Id,
                c => c.Id,
                (l, c) => new ContractorInfo
                {
                    NativeId = c.Id.ToString(),
                    Name = c.Name,
                    FullName = c.FullName,
                    INN = c.INN,
                    OKPO = c.OKPO,
                    LegalAddress = c.LegalAddress
                });

            return q.FirstOrDefault();
        }

    }
}