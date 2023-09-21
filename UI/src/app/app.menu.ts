/* tslint:disable:max-line-length */
import { FuseNavigationItem } from '@fuse/components/navigation';

//#Marcao - MENU - Aqui é o menu de acordo com a rota da pagina e o icone que sera exibido no menu
//#Marcao - ICONS - Link para identificar o nome dos icones https://fonts.google.com/icons

export const defaultNavigation: FuseNavigationItem[] = [
    {
        id   : 'dashboard',
        title: 'Dashboard',
        type : 'basic',
        icon : 'dashboard',
        link : '/dashboard'
    },
    {
        id   : 'example',
        title: 'About',
        type : 'basic',
        icon : 'feed',
        link : '/about'
    },
];

export const compactNavigation: FuseNavigationItem[] = [];
export const futuristicNavigation: FuseNavigationItem[] = [];
export const horizontalNavigation: FuseNavigationItem[] = [];

