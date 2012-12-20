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
    [KnownType(typeof(Provider))]
    [KnownType(typeof(USER))]
    [KnownType(typeof(STOCK))]
    public partial class PURCHASE_ORDER: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int ID_PURCHASE
        {
            get { return _iD_PURCHASE; }
            set
            {
                if (_iD_PURCHASE != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'ID_PURCHASE' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _iD_PURCHASE = value;
                    OnPropertyChanged("ID_PURCHASE");
                }
            }
        }
        private int _iD_PURCHASE;
    
        [DataMember]
        public int ID_PROVIDER
        {
            get { return _iD_PROVIDER; }
            set
            {
                if (_iD_PROVIDER != value)
                {
                    ChangeTracker.RecordOriginalValue("ID_PROVIDER", _iD_PROVIDER);
                    if (!IsDeserializing)
                    {
                        if (PROVIDER != null && PROVIDER.ProviderID != value)
                        {
                            PROVIDER = null;
                        }
                    }
                    _iD_PROVIDER = value;
                    OnPropertyChanged("ID_PROVIDER");
                }
            }
        }
        private int _iD_PROVIDER;
    
        [DataMember]
        public int ID_USER
        {
            get { return _iD_USER; }
            set
            {
                if (_iD_USER != value)
                {
                    ChangeTracker.RecordOriginalValue("ID_USER", _iD_USER);
                    if (!IsDeserializing)
                    {
                        if (USER != null && USER.ID_USER != value)
                        {
                            USER = null;
                        }
                    }
                    _iD_USER = value;
                    OnPropertyChanged("ID_USER");
                }
            }
        }
        private int _iD_USER;
    
        [DataMember]
        public decimal TOTAL_PURCHASE
        {
            get { return _tOTAL_PURCHASE; }
            set
            {
                if (_tOTAL_PURCHASE != value)
                {
                    _tOTAL_PURCHASE = value;
                    OnPropertyChanged("TOTAL_PURCHASE");
                }
            }
        }
        private decimal _tOTAL_PURCHASE;
    
        [DataMember]
        public System.DateTime CREATION_PURCHASE
        {
            get { return _cREATION_PURCHASE; }
            set
            {
                if (_cREATION_PURCHASE != value)
                {
                    _cREATION_PURCHASE = value;
                    OnPropertyChanged("CREATION_PURCHASE");
                }
            }
        }
        private System.DateTime _cREATION_PURCHASE;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public Provider PROVIDER
        {
            get { return _pROVIDER; }
            set
            {
                if (!ReferenceEquals(_pROVIDER, value))
                {
                    var previousValue = _pROVIDER;
                    _pROVIDER = value;
                    FixupPROVIDER(previousValue);
                    OnNavigationPropertyChanged("PROVIDER");
                }
            }
        }
        private Provider _pROVIDER;
    
        [DataMember]
        public USER USER
        {
            get { return _uSER; }
            set
            {
                if (!ReferenceEquals(_uSER, value))
                {
                    var previousValue = _uSER;
                    _uSER = value;
                    FixupUSER(previousValue);
                    OnNavigationPropertyChanged("USER");
                }
            }
        }
        private USER _uSER;
    
        [DataMember]
        public TrackableCollection<STOCK> STOCKs
        {
            get
            {
                if (_sTOCKs == null)
                {
                    _sTOCKs = new TrackableCollection<STOCK>();
                    _sTOCKs.CollectionChanged += FixupSTOCKs;
                }
                return _sTOCKs;
            }
            set
            {
                if (!ReferenceEquals(_sTOCKs, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_sTOCKs != null)
                    {
                        _sTOCKs.CollectionChanged -= FixupSTOCKs;
                        // This is the principal end in an association that performs cascade deletes.
                        // Remove the cascade delete event handler for any entities in the current collection.
                        foreach (STOCK item in _sTOCKs)
                        {
                            ChangeTracker.ObjectStateChanging -= item.HandleCascadeDelete;
                        }
                    }
                    _sTOCKs = value;
                    if (_sTOCKs != null)
                    {
                        _sTOCKs.CollectionChanged += FixupSTOCKs;
                        // This is the principal end in an association that performs cascade deletes.
                        // Add the cascade delete event handler for any entities that are already in the new collection.
                        foreach (STOCK item in _sTOCKs)
                        {
                            ChangeTracker.ObjectStateChanging += item.HandleCascadeDelete;
                        }
                    }
                    OnNavigationPropertyChanged("STOCKs");
                }
            }
        }
        private TrackableCollection<STOCK> _sTOCKs;

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
            PROVIDER = null;
            USER = null;
            STOCKs.Clear();
        }

        #endregion
        #region Association Fixup
    
        private void FixupPROVIDER(Provider previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.PurchasesOrders.Contains(this))
            {
                previousValue.PurchasesOrders.Remove(this);
            }
    
            if (PROVIDER != null)
            {
                if (!PROVIDER.PurchasesOrders.Contains(this))
                {
                    PROVIDER.PurchasesOrders.Add(this);
                }
    
                ID_PROVIDER = PROVIDER.ProviderID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("PROVIDER")
                    && (ChangeTracker.OriginalValues["PROVIDER"] == PROVIDER))
                {
                    ChangeTracker.OriginalValues.Remove("PROVIDER");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("PROVIDER", previousValue);
                }
                if (PROVIDER != null && !PROVIDER.ChangeTracker.ChangeTrackingEnabled)
                {
                    PROVIDER.StartTracking();
                }
            }
        }
    
        private void FixupUSER(USER previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.PURCHASE_ORDER.Contains(this))
            {
                previousValue.PURCHASE_ORDER.Remove(this);
            }
    
            if (USER != null)
            {
                if (!USER.PURCHASE_ORDER.Contains(this))
                {
                    USER.PURCHASE_ORDER.Add(this);
                }
    
                ID_USER = USER.ID_USER;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("USER")
                    && (ChangeTracker.OriginalValues["USER"] == USER))
                {
                    ChangeTracker.OriginalValues.Remove("USER");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("USER", previousValue);
                }
                if (USER != null && !USER.ChangeTracker.ChangeTrackingEnabled)
                {
                    USER.StartTracking();
                }
            }
        }
    
        private void FixupSTOCKs(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (STOCK item in e.NewItems)
                {
                    item.PURCHASE_ORDER = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("STOCKs", item);
                    }
                    // This is the principal end in an association that performs cascade deletes.
                    // Update the event listener to refer to the new dependent.
                    ChangeTracker.ObjectStateChanging += item.HandleCascadeDelete;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (STOCK item in e.OldItems)
                {
                    if (ReferenceEquals(item.PURCHASE_ORDER, this))
                    {
                        item.PURCHASE_ORDER = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("STOCKs", item);
                        // Delete the dependent end of this identifying association. If the current state is Added,
                        // allow the relationship to be changed without causing the dependent to be deleted.
                        if (item.ChangeTracker.State != ObjectState.Added)
                        {
                            item.MarkAsDeleted();
                        }
                    }
                    // This is the principal end in an association that performs cascade deletes.
                    // Remove the previous dependent from the event listener.
                    ChangeTracker.ObjectStateChanging -= item.HandleCascadeDelete;
                }
            }
        }

        #endregion
    }
}