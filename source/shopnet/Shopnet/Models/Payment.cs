//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace Shopnet.Models
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(Sale))]
    public partial class Payment: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int PaymentID
        {
            get { return _paymentID; }
            set
            {
                if (_paymentID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'PaymentID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _paymentID = value;
                    OnPropertyChanged("PaymentID");
                }
            }
        }
        private int _paymentID;
    
        [DataMember]
        public int SaleID
        {
            get { return _saleID; }
            set
            {
                if (_saleID != value)
                {
                    ChangeTracker.RecordOriginalValue("SaleID", _saleID);
                    if (!IsDeserializing)
                    {
                        if (Sale != null && Sale.SaleID != value)
                        {
                            Sale = null;
                        }
                    }
                    _saleID = value;
                    OnPropertyChanged("SaleID");
                }
            }
        }
        private int _saleID;
    
        [DataMember]
        public decimal Mount
        {
            get { return _mount; }
            set
            {
                if (_mount != value)
                {
                    _mount = value;
                    OnPropertyChanged("Mount");
                }
            }
        }
        private decimal _mount;
    
        [DataMember]
        public System.DateTime Creation
        {
            get { return _creation; }
            set
            {
                if (_creation != value)
                {
                    _creation = value;
                    OnPropertyChanged("Creation");
                }
            }
        }
        private System.DateTime _creation;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public Sale Sale
        {
            get { return _sale; }
            set
            {
                if (!ReferenceEquals(_sale, value))
                {
                    var previousValue = _sale;
                    _sale = value;
                    FixupSale(previousValue);
                    OnNavigationPropertyChanged("Sale");
                }
            }
        }
        private Sale _sale;

        #endregion
        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
        private ObjectChangeTracker _changeTracker;
    
        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }
    
        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }
    
        protected bool IsDeserializing { get; private set; }
    
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }
    
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }
    
        protected virtual void ClearNavigationProperties()
        {
            Sale = null;
        }

        #endregion
        #region Association Fixup
    
        private void FixupSale(Sale previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Payments.Contains(this))
            {
                previousValue.Payments.Remove(this);
            }
    
            if (Sale != null)
            {
                if (!Sale.Payments.Contains(this))
                {
                    Sale.Payments.Add(this);
                }
    
                SaleID = Sale.SaleID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Sale")
                    && (ChangeTracker.OriginalValues["Sale"] == Sale))
                {
                    ChangeTracker.OriginalValues.Remove("Sale");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Sale", previousValue);
                }
                if (Sale != null && !Sale.ChangeTracker.ChangeTrackingEnabled)
                {
                    Sale.StartTracking();
                }
            }
        }

        #endregion
    }
}
