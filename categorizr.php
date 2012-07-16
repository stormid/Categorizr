<?php 
/**
* Categorizr Version 1.1
* http://www.brettjankord.com/2012/01/16/categorizr-a-modern-device-detection-script/
* Written by Brett Jankord - Copyright © 2011
* Thanks to Josh Eisma for helping with code review
*
* Big thanks to Rob Manson and http://mob-labs.com for their work on
* the Not-Device Detection strategy:
* http://smartmobtoolkit.wordpress.com/2009/01/26/not-device-detection-javascript-perl-and-php-code/
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU Lesser General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
* GNU Lesser General Public License for more details.
* You should have received a copy of the GNU General Public License
* and GNU Lesser General Public License
* along with this program. If not, see http://www.gnu.org/licenses/.
**/


class categorizr {
  
  const DESKTOP = 'desktop';
  const TABLET = 'tablet';
  const MOBILE = 'mobile';
  const TV = 'tv';
  
  private $useragent = null;
  private $detected = false;

  public $categorize_tablets_as_desktops = false;
  public $categorize_tvs_as_desktops = false;

  public function __construct()
  {
    $this->useragent( $_SERVER[ 'HTTP_USER_AGENT' ] );
  }

  public function useragent( $ua = null )
  {
    if ( $ua )
      {
        $this->useragent = $ua;
      	$this->detected = false;
      }
    else
      return $this->useragent;
  }

  public function detect()
  {
    if ( $this->detected !== false )
      return;
    
    // Check if user agent is a smart TV - http://goo.gl/FocDk
    if ((preg_match('/GoogleTV|SmartTV|Internet.TV|NetCast|NETTV|AppleTV|boxee|Kylo|Roku|DLNADOC|CE\-HTML/i', $this->useragent)))
      $this->detected = self::TV;
    
    // Check if user agent is a TV Based Gaming Console
    else if ((preg_match('/Xbox|PLAYSTATION.3|Wii/i', $this->useragent)))
      $this->detected = self::TV;
    
    // Check if user agent is a Tablet
    else if((preg_match('/iP(a|ro)d/i', $this->useragent)) || (preg_match('/tablet/i', $this->useragent)) && (!preg_match('/RX-34/i', $this->useragent)) || (preg_match('/FOLIO/i', $this->useragent)))
      $this->detected = self::TABLET;
    
    // Check if user agent is an Android Tablet
    else if ((preg_match('/Linux/i', $this->useragent)) && (preg_match('/Android/i', $this->useragent)) && (!preg_match('/Fennec|mobi|HTC.Magic|HTCX06HT|Nexus.One|SC-02B|fone.945/i', $this->useragent)))
      $this->detected = self::TABLET;
    
    // Check if user agent is a Kindle or Kindle Fire
    else if ((preg_match('/Kindle/i', $this->useragent)) || (preg_match('/Mac.OS/i', $this->useragent)) && (preg_match('/Silk/i', $this->useragent)))
      $this->detected = self::TABLET;
    
    // Check if user agent is a pre Android 3.0 Tablet
    else if ((preg_match('/GT-P10|SC-01C|SHW-M180S|SGH-T849|SCH-I800|SHW-M180L|SPH-P100|SGH-I987|zt180|HTC(.Flyer|\_Flyer)|Sprint.ATP51|ViewPad7|pandigital(sprnova|nova)|Ideos.S7|Dell.Streak.7|Advent.Vega|A101IT|A70BHT|MID7015|Next2|nook/i', $this->useragent)) || (preg_match('/MB511/i', $this->useragent)) && (preg_match('/RUTEM/i', $this->useragent)))
      $this->detected = self::TABLET;
    
    // Check if user agent is unique Mobile User Agent	
    else if ((preg_match('/BOLT|Fennec|Iris|Maemo|Minimo|Mobi|mowser|NetFront|Novarra|Prism|RX-34|Skyfire|Tear|XV6875|XV6975|Google.Wireless.Transcoder/i', $this->useragent)))
      $this->detected = self::DESKTOP;
    
    // Check if user agent is an odd Opera User Agent - http://goo.gl/nK90K
    else if ((preg_match('/Opera/i', $this->useragent)) && (preg_match('/Windows.NT.5/i', $this->useragent)) && (preg_match('/HTC|Xda|Mini|Vario|SAMSUNG\-GT\-i8000|SAMSUNG\-SGH\-i9/i', $this->useragent)))
      $this->detected = self::DESKTOP;
    
    // Check if user agent is Windows Desktop
    else if ((preg_match('/Windows.(NT|XP|ME|9)/', $this->useragent)) && (!preg_match('/Phone/i', $this->useragent)) || (preg_match('/Win(9|.9|NT)/i', $this->useragent)))
      $this->detected = self::DESKTOP;
    
    // Check if agent is Mac Desktop
    else if ((preg_match('/Macintosh|PowerPC/i', $this->useragent)) && (!preg_match('/Silk/i', $this->useragent)))
      $this->detected = self::DESKTOP;
    
    // Check if user agent is a Linux Desktop
    else if ((preg_match('/Linux/i', $this->useragent)) && (preg_match('/X11/i', $this->useragent)))
      $this->detected = self::DESKTOP;
    
    // Check if user agent is a Solaris, SunOS, BSD Desktop
    else if ((preg_match('/Solaris|SunOS|BSD/i', $this->useragent)))
      $this->detected = self::DESKTOP;
    
    // Check if user agent is a Desktop BOT/Crawler/Spider
    else if ((preg_match('/Bot|Crawler|Spider|Yahoo|ia_archiver|Covario-IDS|findlinks|DataparkSearch|larbin|Mediapartners-Google|NG-Search|Snappy|Teoma|Jeeves|TinEye/i', $this->useragent)) && (!preg_match('/Mobile/i', $this->useragent)))
      $this->detected = self::DESKTOP;
    
    // Otherwise assume it is a Mobile Device
    else
      $this->detected = self::MOBILE;

    // If we categorize tablets as desktops
    if ( $this->categorize_tablets_as_desktops && $this->detected == self::TABLET )
      $this->detected = self::DESKTOP;
    
    // If we categorize tvs as desktops
    if ( $this->categorize_tvs_as_desktops && $this->detected == self::TV )
      $this->detected = self::DESKTOP;
  }

  public function isMobile()
  {
    $this->detect();
    return $this->detected == self::MOBILE;
  }

  public function isTablet()
  {
    $this->detect();
    return $this->detected == self::TABLET;
  }

  public function isDesktop()
  {
    $this->detect();
    return $this->detected == self::DESKTOP;
  }

  public function isTv()
  {
    $this->detect();
    return $this->detected == self::TV;
  }

}